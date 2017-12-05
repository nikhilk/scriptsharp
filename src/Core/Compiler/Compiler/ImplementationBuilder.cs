// ImplementationBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ScriptSharp;
using ScriptSharp.CodeModel;
using ScriptSharp.ScriptModel;

namespace ScriptSharp.Compiler {

    internal sealed class ImplementationBuilder : ILocalSymbolTable {

        private CompilerOptions _options;
        private IErrorHandler _errorHandler;

        private SymbolScope _rootScope;
        private SymbolScope _currentScope;

        private int _generatedSymbolCount;

        public ImplementationBuilder(CompilerOptions options, IErrorHandler errorHandler) {
            _options = options;
            _errorHandler = errorHandler;
        }

        private SymbolImplementation BuildImplementation(ISymbolTable symbolTable, CodeMemberSymbol symbolContext, BlockStatementNode implementationNode, bool addAllParameters) {
            _rootScope = new SymbolScope(symbolTable);
            _currentScope = _rootScope;

            List<Statement> statements = new List<Statement>();
            StatementBuilder statementBuilder = new StatementBuilder(this, symbolContext, _errorHandler, _options);

            if (symbolContext.Parameters != null) {
                int parameterCount = symbolContext.Parameters.Count;
                if (addAllParameters == false) {
                    // For property getters (including indexers), we don't add the last parameter,
                    // which happens to be the "value" parameter, which only makes sense
                    // for the setter.

                    parameterCount--;
                }
                for (int paramIndex = 0; paramIndex < parameterCount; paramIndex++) {
                    _currentScope.AddSymbol(symbolContext.Parameters[paramIndex]);
                }
            }

            if ((symbolContext.Type == SymbolType.Constructor) &&
                ((((ConstructorSymbol)symbolContext).Visibility & MemberVisibility.Static) == 0)) {
                Debug.Assert(symbolContext.Parent is ClassSymbol);
                if (((ClassSymbol)symbolContext.Parent).BaseClass != null) {
                    BaseInitializerExpression baseExpr = new BaseInitializerExpression();

                    ConstructorDeclarationNode ctorNode = (ConstructorDeclarationNode)symbolContext.ParseContext;
                    if (ctorNode.BaseArguments != null) {
                        ExpressionBuilder expressionBuilder =
                            new ExpressionBuilder(this, symbolContext, _errorHandler, _options);

                        Debug.Assert(ctorNode.BaseArguments is ExpressionListNode);
                        ICollection<Expression> args =
                            expressionBuilder.BuildExpressionList((ExpressionListNode)ctorNode.BaseArguments);

                        foreach (Expression paramExpr in args) {
                            baseExpr.AddParameterValue(paramExpr);
                        }
                    }

                    statements.Add(new ExpressionStatement(baseExpr));
                }
            }

            foreach (StatementNode statementNode in implementationNode.Statements) {
                Statement statement = statementBuilder.BuildStatement(statementNode);
                if (statement != null) {
                    statements.Add(statement);
                }
            }

            string thisIdentifier = "this";
            if (symbolContext.Type == SymbolType.AnonymousMethod) {
                thisIdentifier = "$this";
            }

            return new SymbolImplementation(statements, _rootScope, thisIdentifier);
        }

        public SymbolImplementation BuildEventAdd(EventSymbol eventSymbol) {
            AccessorNode addNode = ((EventDeclarationNode)eventSymbol.ParseContext).Property.SetAccessor;
            BlockStatementNode accessorBody = addNode.Implementation;

            return BuildImplementation((ISymbolTable)eventSymbol.Parent,
                                       eventSymbol, accessorBody, /* addParameters */ true);
        }

        public SymbolImplementation BuildEventRemove(EventSymbol eventSymbol) {
            AccessorNode removeNode = ((EventDeclarationNode)eventSymbol.ParseContext).Property.GetAccessor;
            BlockStatementNode accessorBody = removeNode.Implementation;

            return BuildImplementation((ISymbolTable)eventSymbol.Parent,
                                       eventSymbol, accessorBody, /* addParameters */ true);
        }

        public SymbolImplementation BuildField(FieldSymbol fieldSymbol) {
            _rootScope = new SymbolScope((ISymbolTable)fieldSymbol.Parent);
            _currentScope = _rootScope;

            Expression initializerExpression = null;

            FieldDeclarationNode fieldDeclarationNode = (FieldDeclarationNode)fieldSymbol.ParseContext;
            Debug.Assert(fieldDeclarationNode != null);

            VariableInitializerNode initializerNode = (VariableInitializerNode)fieldDeclarationNode.Initializers[0];
            if (initializerNode.Value != null) {
                ExpressionBuilder expressionBuilder = new ExpressionBuilder(this, fieldSymbol, _errorHandler, _options);
                initializerExpression = expressionBuilder.BuildExpression(initializerNode.Value);
                if (initializerExpression is MemberExpression) {
                    initializerExpression =
                        expressionBuilder.TransformMemberExpression((MemberExpression)initializerExpression);
                }
            }
            else {
                object defaultValue = null;

                TypeSymbol fieldType = fieldSymbol.AssociatedType;
                SymbolSet symbolSet = fieldSymbol.SymbolSet;

                if (fieldType.Type == SymbolType.Enumeration) {
                    // The default for named values is null, so this only applies to
                    // regular enum types

                    EnumerationSymbol enumType = (EnumerationSymbol)fieldType;
                    if (enumType.UseNamedValues == false) {
                        defaultValue = 0;
                    }
                }
                else if ((fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Integer)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedInteger)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Long)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedLong)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Short)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedShort)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Byte)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.SignedByte)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Double)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Single)) ||
                    (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Decimal))) {
                    defaultValue = 0;
                }
                else if (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Boolean)) {
                    defaultValue = false;
                }

                if (defaultValue != null) {
                    initializerExpression =
                        new LiteralExpression(symbolSet.ResolveIntrinsicType(IntrinsicType.Object),
                                              defaultValue);
                    fieldSymbol.SetImplementationState(/* hasInitializer */ true);
                }
            }

            if (initializerExpression != null) {
                List<Statement> statements = new List<Statement>();
                statements.Add(new ExpressionStatement(initializerExpression, /* isFragment */ true));

                return new SymbolImplementation(statements, null, "this");
            }

            return null;
        }

        public SymbolImplementation BuildMethod(MethodSymbol methodSymbol) {
            BlockStatementNode methodBody = ((MethodDeclarationNode)methodSymbol.ParseContext).Implementation;
            return BuildImplementation((ISymbolTable)methodSymbol.Parent,
                                       methodSymbol, methodBody, /* addAllParameters */ true);
        }

        public SymbolImplementation BuildMethod(AnonymousMethodSymbol methodSymbol) {
            BlockStatementNode methodBody = ((AnonymousMethodNode)methodSymbol.ParseContext).Implementation;
            return BuildImplementation(methodSymbol.StackContext,
                                       methodSymbol, methodBody, /* addAllParameters */ true);
        }

        public SymbolImplementation BuildIndexerGetter(IndexerSymbol indexerSymbol) {
            AccessorNode getterNode = ((IndexerDeclarationNode)indexerSymbol.ParseContext).GetAccessor;
            BlockStatementNode accessorBody = getterNode.Implementation;

            return BuildImplementation((ISymbolTable)indexerSymbol.Parent,
                                       indexerSymbol, accessorBody, /* addAllParameters */ false);
        }

        public SymbolImplementation BuildIndexerSetter(IndexerSymbol indexerSymbol) {
            AccessorNode setterNode = ((IndexerDeclarationNode)indexerSymbol.ParseContext).SetAccessor;
            BlockStatementNode accessorBody = setterNode.Implementation;

            return BuildImplementation((ISymbolTable)indexerSymbol.Parent,
                                       indexerSymbol, accessorBody, /* addAllParameters */ true);
        }

        public SymbolImplementation BuildPropertyGetter(PropertySymbol propertySymbol) {
            AccessorNode getterNode = ((PropertyDeclarationNode)propertySymbol.ParseContext).GetAccessor;
            if (getterNode == null)
            {
                return null;
            }
            BlockStatementNode accessorBody = getterNode.Implementation;

            return BuildImplementation((ISymbolTable)propertySymbol.Parent,
                                       propertySymbol, accessorBody, /* addAllParameters */ false);
        }

        public SymbolImplementation BuildPropertySetter(PropertySymbol propertySymbol) {
            AccessorNode setterNode = ((PropertyDeclarationNode)propertySymbol.ParseContext).SetAccessor;
            if (setterNode == null)
            {
                return null;
            }
            BlockStatementNode accessorBody = setterNode.Implementation;

            return BuildImplementation((ISymbolTable)propertySymbol.Parent,
                                       propertySymbol, accessorBody, /* addAllParameters */ true);
        }

        #region ISymbolTable Members
        ICollection ISymbolTable.Symbols {
            get {
                Debug.Assert(_currentScope != null);
                return ((ISymbolTable)_currentScope).Symbols;
            }
        }

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter) {
            Debug.Assert(_currentScope != null);
            return ((ISymbolTable)_currentScope).FindSymbol(name, context, filter);
        }
        #endregion

        #region ILocalSymbolTable Members
        void ILocalSymbolTable.AddSymbol(LocalSymbol symbol) {
            Debug.Assert(_currentScope != null);
            _currentScope.AddSymbol(symbol);
        }

        string ILocalSymbolTable.CreateSymbolName(string nameHint) {
            _generatedSymbolCount++;
            return "$" + nameHint + _generatedSymbolCount;
        }

        void ILocalSymbolTable.PopScope() {
            Debug.Assert(_currentScope != null);
            _currentScope = _currentScope.Parent;
        }

        void ILocalSymbolTable.PushScope() {
            Debug.Assert(_currentScope != null);
            
            SymbolScope parentScope = _currentScope;

            _currentScope = new SymbolScope(parentScope);
            parentScope.AddChildScope(_currentScope);
        }
        #endregion
    }
}
