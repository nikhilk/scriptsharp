using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSharp.Compiler.CodeModel;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.Validator
{
    /// <summary>
    ///     Validates the code model based on the constrained subset of C# supposed
    ///     in Script#.
    /// </summary>
    internal sealed class CodeModelValidator : IParseNodeHandler
    {
        private readonly IErrorHandler errorHandler;
        private readonly Dictionary<Type, IParseNodeValidator> validatorTable;

        public CodeModelValidator(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
            validatorTable = new Dictionary<Type, IParseNodeValidator>();
        }

        private Type GetValidatorType(ParseNodeType nodeType, CompilerOptions options)
        {
            switch (nodeType)
            {
                case ParseNodeType.CompilationUnit:

                    return typeof(CompilationUnitNodeValidator);
                case ParseNodeType.Namespace:

                    return typeof(NamespaceNodeValidator);
                case ParseNodeType.Name:
                case ParseNodeType.GenericName:

                    return typeof(NameNodeValidator);
                case ParseNodeType.Type:

                    return typeof(CustomTypeNodeValidator);
                case ParseNodeType.ArrayType:

                    return typeof(ArrayTypeNodeValidator);
                case ParseNodeType.FormalParameter:

                    return typeof(ParameterNodeValidator);
                case ParseNodeType.EnumerationFieldDeclaration:

                    return typeof(EnumerationFieldNodeValidator);
                case ParseNodeType.FieldDeclaration:
                case ParseNodeType.ConstFieldDeclaration:

                    return typeof(FieldDeclarationNodeValidator);
                case ParseNodeType.IndexerDeclaration:

                    return typeof(IndexerDeclarationNodeValidator);
                case ParseNodeType.PropertyDeclaration:

                    return typeof(PropertyDeclarationNodeValidator);
                case ParseNodeType.EventDeclaration:

                    return typeof(EventDeclarationNodeValidator);
                case ParseNodeType.MethodDeclaration:
                case ParseNodeType.ConstructorDeclaration:

                    return typeof(MethodDeclarationNodeValidator);
                case ParseNodeType.Throw:

                    return typeof(ThrowNodeValidator);
                case ParseNodeType.Try:

                    return typeof(TryNodeValidator);
                case ParseNodeType.ArrayNew:

                    return typeof(ArrayNewNodeValidator);
                case ParseNodeType.New:

                    return typeof(NewNodeValidator);
                case ParseNodeType.Catch:
                case ParseNodeType.ArrayInitializer:
                case ParseNodeType.Literal:
                case ParseNodeType.AttributeBlock:
                case ParseNodeType.Attribute:
                case ParseNodeType.AccessorDeclaration:
                case ParseNodeType.VariableDeclaration:
                case ParseNodeType.ConstDeclaration:
                case ParseNodeType.MultiPartName:
                case ParseNodeType.UsingNamespace:
                case ParseNodeType.PredefinedType:
                case ParseNodeType.UnaryExpression:
                case ParseNodeType.Conditional:
                case ParseNodeType.Block:
                case ParseNodeType.ExpressionStatement:
                case ParseNodeType.EmptyStatement:
                case ParseNodeType.VariableDeclarator:
                case ParseNodeType.IfElse:
                case ParseNodeType.Switch:
                case ParseNodeType.SwitchSection:
                case ParseNodeType.For:
                case ParseNodeType.Foreach:
                case ParseNodeType.While:
                case ParseNodeType.DoWhile:
                case ParseNodeType.CaseLabel:
                case ParseNodeType.DefaultLabel:
                case ParseNodeType.This:
                case ParseNodeType.Base:
                case ParseNodeType.Cast:
                case ParseNodeType.ExpressionList:
                case ParseNodeType.Break:
                case ParseNodeType.Continue:
                case ParseNodeType.Return:
                case ParseNodeType.Typeof:
                case ParseNodeType.Delegate:
                case ParseNodeType.UsingAlias:
                case ParseNodeType.AnonymousMethod:
                case ParseNodeType.BinaryExpression:
                case ParseNodeType.Using:
                case ParseNodeType.ObjectInitializer:
                case ParseNodeType.TypeParameter:

                    // No validation required
                    break;
                case ParseNodeType.PointerType:
                case ParseNodeType.OperatorDeclaration:
                case ParseNodeType.DestructorDeclaration:
                case ParseNodeType.Goto:
                case ParseNodeType.Lock:
                case ParseNodeType.UnsafeStatement:
                case ParseNodeType.YieldReturn:
                case ParseNodeType.YieldBreak:
                case ParseNodeType.LabeledStatement:
                case ParseNodeType.Checked:
                case ParseNodeType.Unchecked:
                case ParseNodeType.Sizeof:
                case ParseNodeType.Fixed:
                case ParseNodeType.StackAlloc:
                case ParseNodeType.DefaultValueExpression:
                case ParseNodeType.ExternAlias:
                case ParseNodeType.AliasQualifiedName:
                case ParseNodeType.ConstraintClause:

                    return typeof(UnsupportedParseNodeValidator);
                default:
                    Debug.Fail("Unexpected node type in validator: " + nodeType);

                    break;
            }

            return null;
        }

        #region IParseNodeHandler Members

        bool IParseNodeHandler.RequiresChildrenGrouping => false;

        bool IParseNodeHandler.HandleNode(ParseNode node, object context)
        {
            CompilerOptions options = (CompilerOptions)context;

            Type validatorType = GetValidatorType(node.NodeType, options);

            if (validatorType == null)
            {
                // valid; continue with children...
                return true;
            }

            IParseNodeValidator validator = null;

            if (validatorTable.ContainsKey(validatorType))
            {
                validator = validatorTable[validatorType];
            }
            else
            {
                validator = (IParseNodeValidator)Activator.CreateInstance(validatorType);
                validatorTable[validatorType] = validator;
            }

            return validator.Validate(node, options, errorHandler);
        }

        void IParseNodeHandler.StartChildren(string identifier)
        {
        }

        void IParseNodeHandler.EndChildren()
        {
        }

        #endregion
    }
}
