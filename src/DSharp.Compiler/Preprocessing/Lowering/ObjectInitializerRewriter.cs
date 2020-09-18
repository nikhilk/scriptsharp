using System;
using System.Linq;
using DSharp.Compiler.Errors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class ObjectInitializerRewriter : CSharpSyntaxRewriter, ILowerer
    {
        const string ANONYMOUS_TYPE_NAME = "__AnonymousType__";
        private readonly IErrorHandler errorHandler;
        private SemanticModel sem;
        private bool requiresSystemUsing;

        public ObjectInitializerRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);

            var newRoot = Visit(root) as CompilationUnitSyntax;

            if (requiresSystemUsing && !newRoot.Usings.Any(u => u.Name.ToString() == "System"))
            {
                newRoot = newRoot.AddUsings(
                    UsingDirective(
                        ParseName("System").WithLeadingTrivia(Space)
                        ).WithTrailingTrivia(CarriageReturnLineFeed)
                    );
            }

            return newRoot;
        }

        public override SyntaxNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (node.Initializer == null || IsAnonymousType(node))
            {
                return base.VisitObjectCreationExpression(node);
            }

            ObjectCreationExpressionSyntax newNode = (ObjectCreationExpressionSyntax)base.VisitObjectCreationExpression(node);

            var openBrace = newNode.Initializer.OpenBraceToken;
            var closeBrace = newNode.Initializer.CloseBraceToken;

            IdentifierNameSyntax obj = IdentifierName("_obj_");

            var constructObject = GenerateObject(newNode.Type.WithoutTrailingTrivia(), obj.Identifier, node.ArgumentList)
                .WithTrailingTrivia(openBrace.TrailingTrivia)
                .WithLeadingTrivia((newNode.ArgumentList?.GetTrailingTrivia() ?? newNode.Type.GetTrailingTrivia()).AddRange(openBrace.LeadingTrivia));

            StatementSyntax[] statements = GetInitialiserFunctionStatements(node, newNode, obj);

            var returnObject = ReturnStatement(obj.WithLeadingTrivia(Space)).WithLeadingTrivia(closeBrace.LeadingTrivia);

            var func = GenerateFunction(constructObject, statements, returnObject);

            requiresSystemUsing = true;
            return GenerateInvocation(newNode, func);
        }

        private static bool IsAnonymousType(ObjectCreationExpressionSyntax node)
        {
            return node.Type.ToString().Equals(ANONYMOUS_TYPE_NAME);
        }

        private StatementSyntax[] GetInitialiserFunctionStatements(ObjectCreationExpressionSyntax node, ObjectCreationExpressionSyntax newNode, IdentifierNameSyntax obj)
        {
            if (newNode.Initializer.Kind() == SyntaxKind.CollectionInitializerExpression)
            {
                return newNode.Initializer.Expressions
                .Select((e, i) => GenerateAddInvocation(obj, e, GetTrailingPropertyTrivia(i, node.Initializer.Expressions)))
                .ToArray();
            }
            else if (newNode.Initializer.Kind() == SyntaxKind.ObjectInitializerExpression)
            {
                return newNode.Initializer.Expressions
                .Cast<AssignmentExpressionSyntax>()
                .Select((e, i) => ProcessPropertyExpression(obj, e, GetTrailingPropertyTrivia(i, node.Initializer.Expressions)))
                .ToArray();
            }

            errorHandler.ReportExpressionError("unknown object Initializer", newNode.Initializer);
            return null;
        }

        private StatementSyntax GenerateAddInvocation(IdentifierNameSyntax obj, ExpressionSyntax e, SyntaxTriviaList trailingTrivia)
        {
            var invocation = InvocationExpression(
                expression: MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, obj, IdentifierName("Add")),
                argumentList: GetAddArguments(e)
            );

            return ExpressionStatement(invocation).WithTrailingTrivia(trailingTrivia);
        }

        private ArgumentListSyntax GetAddArguments(ExpressionSyntax e)
        {
            if(e.Kind() == SyntaxKind.ComplexElementInitializerExpression && e is InitializerExpressionSyntax initializer)
            {
                return ArgumentList(arguments: SeparatedList(initializer.Expressions.Select(ex => Argument(ex).WithoutLeadingTrivia())));
            }

            return ArgumentList(arguments: SingletonSeparatedList(Argument(e).WithoutLeadingTrivia()));
        }

        private static AnonymousMethodExpressionSyntax GenerateFunction(LocalDeclarationStatementSyntax constructObject, StatementSyntax[] initialiseProperties, ReturnStatementSyntax returnObject)
        {
            return AnonymousMethodExpression(
                body: Block(
                    openBraceToken: Token(SyntaxKind.OpenBraceToken),
                    statements: SingletonList<StatementSyntax>(constructObject),
                    closeBraceToken: Token(SyntaxKind.CloseBraceToken))
                    .AddStatements(initialiseProperties)
                    .AddStatements(returnObject)
            );
        }

        private static SyntaxNode GenerateInvocation(ObjectCreationExpressionSyntax newNode, AnonymousMethodExpressionSyntax func)
        {
            return InvocationExpression(
                expression: MemberAccessExpression(
                    kind: SyntaxKind.SimpleMemberAccessExpression,
                    expression: ParenthesizedExpression(CastExpression(
                            type: ParseTypeName($"Func<{newNode.Type}>"),
                            expression: func
                        )
                    ),
                    name: IdentifierName(nameof(Action.Invoke))
                )
            );
        }

        private static SyntaxTriviaList GetTrailingPropertyTrivia(int i, SeparatedSyntaxList<ExpressionSyntax> expressions)
        {
            return expressions.SeparatorCount > i ? expressions.GetSeparator(i).TrailingTrivia : expressions[i].GetTrailingTrivia();
        }

        private static LocalDeclarationStatementSyntax GenerateObject(TypeSyntax type, SyntaxToken objectIdentifier, ArgumentListSyntax constructorArgs)
        {
            return LocalDeclarationStatement(
                            VariableDeclaration(type)
                            .WithVariables(
                                SingletonSeparatedList(
                                    VariableDeclarator(objectIdentifier.WithLeadingTrivia(Space))
                                    .WithInitializer(
                                        EqualsValueClause(
                                            ObjectCreationExpression(type.WithLeadingTrivia(Space))
                                            .WithArgumentList(constructorArgs)
                                        )
                                    )
                                )
                            )
                        );
        }

        public StatementSyntax ProcessPropertyExpression(IdentifierNameSyntax obj, AssignmentExpressionSyntax assignmentExpression, SyntaxTriviaList trailingTrivia)
        {
            var expression = assignmentExpression.WithLeft(
                MemberAccessExpression(
                    kind: SyntaxKind.SimpleMemberAccessExpression,
                    expression: obj,
                    name: (IdentifierNameSyntax)assignmentExpression.Left.WithoutLeadingTrivia()
                )
            ).WithLeadingTrivia(assignmentExpression.GetLeadingTrivia());

            return ExpressionStatement(expression).WithTrailingTrivia(trailingTrivia);
        }
    }
}
