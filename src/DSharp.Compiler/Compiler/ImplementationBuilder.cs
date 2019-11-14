// ImplementationBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.CodeModel.Expressions;
using DSharp.Compiler.CodeModel.Members;
using DSharp.Compiler.CodeModel.Names;
using DSharp.Compiler.CodeModel.Statements;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.Errors;
using DSharp.Compiler.ScriptModel.Expressions;
using DSharp.Compiler.ScriptModel.Statements;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Compiler
{
    internal sealed class ImplementationBuilder : ILocalSymbolTable
    {
        private readonly IErrorHandler errorHandler;

        private readonly CompilerOptions options;
        private SymbolScope currentScope;

        private int generatedSymbolCount;

        private SymbolScope rootScope;

        public ImplementationBuilder(CompilerOptions options, IErrorHandler errorHandler)
        {
            this.options = options;
            this.errorHandler = errorHandler;
        }

        private SymbolImplementation BuildImplementation(ISymbolTable symbolTable, CodeMemberSymbol symbolContext,
                                                         BlockStatementNode implementationNode, bool addAllParameters)
        {
            rootScope = new SymbolScope(symbolTable);
            currentScope = rootScope;

            List<Statement> statements = new List<Statement>();
            StatementBuilder statementBuilder = new StatementBuilder(this, symbolContext, errorHandler, options);

            if (symbolContext.Parameters != null)
            {
                int parameterCount = symbolContext.Parameters.Count;

                if (addAllParameters == false)
                {
                    // For property getters (including indexers), we don't add the last parameter,
                    // which happens to be the "value" parameter, which only makes sense
                    // for the setter.

                    parameterCount--;
                }

                for (int paramIndex = 0; paramIndex < parameterCount; paramIndex++)
                    currentScope.AddSymbol(symbolContext.Parameters[paramIndex]);
            }

            if (symbolContext.Type == SymbolType.Constructor &&
                (((ConstructorSymbol) symbolContext).Visibility & MemberVisibility.Static) == 0)
            {
                Debug.Assert(symbolContext.Parent is ClassSymbol);

                if (((ClassSymbol) symbolContext.Parent).BaseClass != null)
                {
                    BaseInitializerExpression baseExpr = new BaseInitializerExpression();

                    ConstructorDeclarationNode ctorNode = (ConstructorDeclarationNode) symbolContext.ParseContext;

                    if (ctorNode.BaseArguments != null)
                    {
                        ExpressionBuilder expressionBuilder =
                            new ExpressionBuilder(this, symbolContext, errorHandler, options);

                        Debug.Assert(ctorNode.BaseArguments is ExpressionListNode);
                        ICollection<Expression> args =
                            expressionBuilder.BuildExpressionList((ExpressionListNode) ctorNode.BaseArguments);

                        foreach (Expression paramExpr in args) baseExpr.AddParameterValue(paramExpr);
                    }

                    statements.Add(new ExpressionStatement(baseExpr));
                }
            }

            foreach (StatementNode statementNode in implementationNode.Statements)
            {
                Statement statement = statementBuilder.BuildStatement(statementNode);

                if (statement != null)
                {
                    statements.Add(statement);
                }
            }

            string thisIdentifier = "this";

            if (symbolContext.Type == SymbolType.AnonymousMethod)
            {
                thisIdentifier = "$this";
            }

            return new SymbolImplementation(statements, rootScope, thisIdentifier);
        }

        private IEnumerable<Statement> ExpandInitializerStatements(StatementBuilder statementBuilder, VariableDeclarationNode variableDeclarationNode)
        {
            var variableInitializer = variableDeclarationNode.Initializers.First()
                .As<VariableInitializerNode>();

            var objectInitializer = variableInitializer.Value
                .As<ObjectInitializerNode>();

            List<Statement> statements = new List<Statement>();

            foreach (var initializerStatement in objectInitializer.ObjectAssignmentExpressions)
            {
                var originalStatement = initializerStatement;
                if (originalStatement is BinaryExpressionNode binaryExpressionNode && binaryExpressionNode.LeftChild is NameNode)
                {
                    var objectInitializerAccess = new BinaryExpressionNode(variableInitializer.Name, TokenType.Dot, binaryExpressionNode.LeftChild);
                    var assignmentExpression = new BinaryExpressionNode(objectInitializerAccess, binaryExpressionNode.Operator, binaryExpressionNode.RightChild);
                    var fullObjectInitializerExpression = new ExpressionStatementNode(assignmentExpression);
                    statements.Add(statementBuilder.BuildStatement(fullObjectInitializerExpression));
                }
            }

            return statements;
        }

        public SymbolImplementation BuildEventAdd(EventSymbol eventSymbol)
        {
            AccessorNode addNode = ((EventDeclarationNode) eventSymbol.ParseContext).Property.SetAccessor;
            BlockStatementNode accessorBody = addNode.Implementation;

            return BuildImplementation((ISymbolTable) eventSymbol.Parent,
                eventSymbol, accessorBody, /* addParameters */ true);
        }

        public SymbolImplementation BuildEventRemove(EventSymbol eventSymbol)
        {
            AccessorNode removeNode = ((EventDeclarationNode) eventSymbol.ParseContext).Property.GetAccessor;
            BlockStatementNode accessorBody = removeNode.Implementation;

            return BuildImplementation((ISymbolTable) eventSymbol.Parent,
                eventSymbol, accessorBody, /* addParameters */ true);
        }

        public SymbolImplementation BuildField(FieldSymbol fieldSymbol)
        {
            rootScope = new SymbolScope((ISymbolTable) fieldSymbol.Parent);
            currentScope = rootScope;

            Expression initializerExpression = null;

            FieldDeclarationNode fieldDeclarationNode = (FieldDeclarationNode) fieldSymbol.ParseContext;
            Debug.Assert(fieldDeclarationNode != null);

            VariableInitializerNode initializerNode = (VariableInitializerNode) fieldDeclarationNode.Initializers[0];

            if (initializerNode.Value != null)
            {
                ExpressionBuilder expressionBuilder = new ExpressionBuilder(this, fieldSymbol, errorHandler, options);
                initializerExpression = expressionBuilder.BuildExpression(initializerNode.Value);

                if (initializerExpression is MemberExpression)
                {
                    initializerExpression =
                        expressionBuilder.TransformMemberExpression((MemberExpression) initializerExpression);
                }
            }
            else
            {
                object defaultValue = null;

                TypeSymbol fieldType = fieldSymbol.AssociatedType;
                SymbolSet symbolSet = fieldSymbol.SymbolSet;

                if (fieldType.Type == SymbolType.Enumeration)
                {
                    // The default for named values is null, so this only applies to
                    // regular enum types

                    EnumerationSymbol enumType = (EnumerationSymbol) fieldType;

                    if (enumType.UseNamedValues == false)
                    {
                        defaultValue = 0;
                    }
                }
                else if (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Integer) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedInteger) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Long) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedLong) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Short) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.UnsignedShort) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Byte) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.SignedByte) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Double) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Single) ||
                         fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Decimal))
                {
                    defaultValue = 0;
                }
                else if (fieldType == symbolSet.ResolveIntrinsicType(IntrinsicType.Boolean))
                {
                    defaultValue = false;
                }

                if (defaultValue != null)
                {
                    initializerExpression =
                        new LiteralExpression(symbolSet.ResolveIntrinsicType(IntrinsicType.Object),
                            defaultValue);
                    fieldSymbol.SetImplementationState( /* hasInitializer */ true);
                }
            }

            if (initializerExpression != null)
            {
                List<Statement> statements = new List<Statement>();
                statements.Add(new ExpressionStatement(initializerExpression, /* isFragment */ true));

                return new SymbolImplementation(statements, null, "this");
            }

            return null;
        }

        public SymbolImplementation BuildMethod(MethodSymbol methodSymbol)
        {
            BlockStatementNode methodBody = ((MethodDeclarationNode) methodSymbol.ParseContext).Implementation;

            return BuildImplementation((ISymbolTable) methodSymbol.Parent,
                methodSymbol, methodBody, /* addAllParameters */ true);
        }

        public SymbolImplementation BuildMethod(AnonymousMethodSymbol methodSymbol)
        {
            BlockStatementNode methodBody = ((AnonymousMethodNode) methodSymbol.ParseContext).Implementation;

            return BuildImplementation(methodSymbol.StackContext,
                methodSymbol, methodBody, /* addAllParameters */ true);
        }

        public SymbolImplementation BuildIndexerGetter(IndexerSymbol indexerSymbol)
        {
            AccessorNode getterNode = ((IndexerDeclarationNode) indexerSymbol.ParseContext).GetAccessor;
            BlockStatementNode accessorBody = getterNode.Implementation;

            return BuildImplementation((ISymbolTable) indexerSymbol.Parent,
                indexerSymbol, accessorBody, /* addAllParameters */ false);
        }

        public SymbolImplementation BuildIndexerSetter(IndexerSymbol indexerSymbol)
        {
            AccessorNode setterNode = ((IndexerDeclarationNode) indexerSymbol.ParseContext).SetAccessor;
            BlockStatementNode accessorBody = setterNode.Implementation;

            return BuildImplementation((ISymbolTable) indexerSymbol.Parent,
                indexerSymbol, accessorBody, /* addAllParameters */ true);
        }

        public bool TryBuildPropertyGetter(PropertySymbol propertySymbol, out SymbolImplementation symbolImplementation)
        {
            AccessorNode getterNode = propertySymbol.GetPropertyNode().GetAccessor;

            if (getterNode == null || getterNode.IsAutoProperty)
            {
                symbolImplementation = null;
                return false;
            }

            BlockStatementNode accessorBody = getterNode.Implementation;

            symbolImplementation = BuildImplementation((ISymbolTable) propertySymbol.Parent,
                propertySymbol, accessorBody, addAllParameters: false);
            return symbolImplementation != null;
        }

        public bool TryBuildPropertySetter(PropertySymbol propertySymbol, out SymbolImplementation symbolImplementation)
        {
            AccessorNode setterNode = propertySymbol.GetPropertyNode().SetAccessor;

            if (setterNode == null || setterNode.IsAutoProperty)
            {
                symbolImplementation = null;
                return false;
            }

            BlockStatementNode accessorBody = setterNode.Implementation;

            symbolImplementation = BuildImplementation((ISymbolTable) propertySymbol.Parent,
                propertySymbol, accessorBody, addAllParameters: true);
            return symbolImplementation != null;

        }

        #region ISymbolTable Members

        ICollection ISymbolTable.Symbols
        {
            get
            {
                Debug.Assert(currentScope != null);

                return ((ISymbolTable) currentScope).Symbols;
            }
        }

        Symbol ISymbolTable.FindSymbol(string name, Symbol context, SymbolFilter filter)
        {
            Debug.Assert(currentScope != null);

            return ((ISymbolTable) currentScope).FindSymbol(name, context, filter);
        }

        #endregion

        #region ILocalSymbolTable Members

        void ILocalSymbolTable.AddSymbol(LocalSymbol symbol)
        {
            Debug.Assert(currentScope != null);
            currentScope.AddSymbol(symbol);
        }

        string ILocalSymbolTable.CreateSymbolName(string nameHint)
        {
            generatedSymbolCount++;

            return "$" + nameHint + generatedSymbolCount;
        }

        void ILocalSymbolTable.PopScope()
        {
            Debug.Assert(currentScope != null);
            currentScope = currentScope.Parent;
        }

        void ILocalSymbolTable.PushScope()
        {
            Debug.Assert(currentScope != null);

            SymbolScope parentScope = currentScope;

            currentScope = new SymbolScope(parentScope);
            parentScope.AddChildScope(currentScope);
        }

        #endregion
    }
}
