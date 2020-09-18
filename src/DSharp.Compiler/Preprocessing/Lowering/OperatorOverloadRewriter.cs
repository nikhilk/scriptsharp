using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    internal class OperatorOverloadRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private INamedTypeSymbol booleanType;
        private SemanticModel sem;
        private static readonly SymbolDisplayFormat displayFormat = new SymbolDisplayFormat(
                    genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                    typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
                    miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.UseSpecialTypes
                );

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            this.booleanType = compilation.GetSpecialType(SpecialType.System_Boolean);
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            var newRoot = Visit(root) as CompilationUnitSyntax;
            return newRoot;
        }

        public override SyntaxNode VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            var symbol = sem.GetDeclaredSymbol(node);
            var newNode = (OperatorDeclarationSyntax)base.VisitOperatorDeclaration(node);

            return MethodDeclaration(
                attributeLists: newNode.AttributeLists,
                modifiers: newNode.Modifiers,
                returnType: newNode.ReturnType,
                identifier: Identifier(symbol.Name)
                    .WithLeadingTrivia(newNode.OperatorToken.LeadingTrivia)
                    .WithTrailingTrivia(newNode.OperatorToken.TrailingTrivia),
                parameterList:newNode.ParameterList,
                body: newNode.Body,
                typeParameterList: default,
                constraintClauses: default,
                explicitInterfaceSpecifier: default,
                expressionBody:default
            );
        }

        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            var newNode = base.VisitBinaryExpression(node);

            if (GetOperatorMethod(node) is IMethodSymbol operatorMethod)
            {
                if(operatorMethod.GetAttributes().Any(a=>a.AttributeClass.Name.StartsWith("ScriptIgnore")))
                {
                    return newNode;
                }

                return GenerateOperatorInvocation(operatorMethod, Argument(node.Left), Argument(node.Right));

            }

            return newNode;
        }

        public override SyntaxNode VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            var newNode = (PostfixUnaryExpressionSyntax)base.VisitPostfixUnaryExpression(node);

            if (GetOperatorMethod(node) is IMethodSymbol operatorMethod)
            {
                if (operatorMethod.GetAttributes().Any(a => a.AttributeClass.Name.StartsWith("ScriptIgnore")))
                {
                    return newNode;
                }

                return GenerateOperatorInvocation(operatorMethod, Argument(newNode.Operand));
            }

            return newNode;
        }

        private IMethodSymbol GetOperatorMethod(SyntaxNode node)
        {
            return GetOperatorMethod(sem.GetOperation(node));
        }

        private IMethodSymbol GetOperatorMethod(IOperation operation)
        {
            switch (operation)
            {
                case IUnaryOperation unaryOperation:
                    return unaryOperation.OperatorMethod;

                case IBinaryOperation binaryOperation:
                    return binaryOperation.OperatorMethod;

                case IIncrementOrDecrementOperation incrementOrDecrementOperation:
                    return incrementOrDecrementOperation.OperatorMethod;

                case ICompoundAssignmentOperation compoundAssignmentOperation:
                    return compoundAssignmentOperation.OperatorMethod;

                default: 
                    return null;
            }
        }

        public override SyntaxNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            var newNode = (PrefixUnaryExpressionSyntax)base.VisitPrefixUnaryExpression(node);

            if (GetOperatorMethod(node) is IMethodSymbol operatorMethod)
            {
                if (operatorMethod.GetAttributes().Any(a => a.AttributeClass.Name.StartsWith("ScriptIgnore")))
                {
                    return newNode;
                }

                return GenerateOperatorInvocation(operatorMethod, Argument(newNode.Operand));
            }

            return newNode;
        }

        private static InvocationExpressionSyntax GenerateOperatorInvocation(IMethodSymbol operatorMethod, params ArgumentSyntax[] args)
        {
            var identifier = IdentifierName(operatorMethod.Name);
            var type = ParseTypeName(operatorMethod.ContainingType.ToDisplayString(displayFormat));
            
            return InvocationExpression(
                expression: MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, type, identifier),
                argumentList: ArgumentList(Token(SyntaxKind.OpenParenToken), SeparatedList(args), Token(SyntaxKind.CloseParenToken))
            );
        }

        public override SyntaxNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            var newNode = (AssignmentExpressionSyntax)base.VisitAssignmentExpression(node);
            
            if (GetOperatorMethod(node) is IMethodSymbol operatorMethod)
            {
                if (operatorMethod.GetAttributes().Any(a => a.AttributeClass.Name.StartsWith("ScriptIgnore")))
                {
                    return newNode;
                }

                return AssignmentExpression(
                    kind: SyntaxKind.SimpleAssignmentExpression,
                    left: newNode.Left,
                    right: GenerateOperatorInvocation(operatorMethod, Argument(newNode.Left), Argument(newNode.Right)));
            }

            return newNode;
        }
        
        ////TODO: add support for true operator
        //public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        //{
        //    var newNode = (IdentifierNameSyntax)base.VisitIdentifierName(node);
        //    var operation = sem.GetOperation(node)?.Parent;
        //    if (operation is IUnaryOperation unaryOperation && (unaryOperation.OperatorKind == UnaryOperatorKind.True || unaryOperation.OperatorKind == UnaryOperatorKind.False) && GetOperatorMethod(operation) is IMethodSymbol operatorMethod)
        //    {
        //        if(operatorMethod.GetAttributes().Any(a => a.AttributeClass.Name.StartsWith("ScriptIgnore")))
        //        {
        //            return newNode;
        //        }

        //        return GenerateOperatorInvocation(operatorMethod, Argument(newNode));
        //    }

        //    return base.VisitIdentifierName(node);
        //}
    }
}
