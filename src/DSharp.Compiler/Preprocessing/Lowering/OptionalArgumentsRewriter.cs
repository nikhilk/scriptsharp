using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.Errors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class OptionalArgumentsRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;
        private readonly IErrorHandler errorHandler;
        private HashSet<string> requiredUsings;

        public OptionalArgumentsRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            requiredUsings = new HashSet<string>();

            var newRoot = Visit(root) as CompilationUnitSyntax;

            var missingUsings = requiredUsings.Where(r => !string.IsNullOrWhiteSpace(r)).Where(r => !root.Usings.Select(u => u.Name.ToString()).Contains(r));

            if (missingUsings.Any())
            {
                var missingDirectives = missingUsings.Select(s => UsingDirective(ParseName(s).WithLeadingTrivia(Whitespace(" ")))).ToArray();
                newRoot = newRoot.AddUsings(missingDirectives);
            }

            return newRoot;
        }

        public override SyntaxNode VisitParameter(ParameterSyntax node)
        {
            if (node.Default is EqualsValueClauseSyntax)
            {
                return node.WithDefault(null);
            }

            return base.VisitParameter(node);
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var newNode = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node);

            if (sem.GetDeclaredSymbol(node) is IMethodSymbol methodSymbol)
            {
                if (methodSymbol.Parameters.Any(p => p.HasExplicitDefaultValue))
                {
                    if (VisitBlock(newNode.Body) is BlockSyntax body)
                    {
                        requiredUsings.Add("System");
                        var defaults = methodSymbol.Parameters.Select((property, index) => (property,index)).Where(p => p.property.HasExplicitDefaultValue).Select(p => GenerateDefaultExpression(p.property, p.index, node.GetLocation()));
                        body = body.WithStatements(body.Statements.InsertRange(0, defaults));
                        return newNode.WithBody(body);
                    }
                }
            }

            return newNode;
        }

        private StatementSyntax GenerateDefaultExpression(IParameterSymbol parameterSymbol, int index, Location location)
        {
            if (parameterSymbol.DeclaringSyntaxReferences.First().GetSyntax() is ParameterSyntax parameterSyntax)
            {
                return ExpressionStatement(
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        IdentifierName(parameterSyntax.Identifier),
                        ConditionalExpression(
                            condition: InvocationExpression(
                                expression: MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                                    IdentifierName("Arguments"),
                                    IdentifierName("HasArgument")
                                ),
                                argumentList: ArgumentList(SingletonSeparatedList(Argument(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(index)))))
                            ),
                            whenTrue: IdentifierName(parameterSyntax.Identifier),
                            whenFalse: parameterSyntax.Default.Value
                        )
                    )
                );
            }
            else
            {
                errorHandler.ReportError(new CompilerError(
                    errorCode: (ushort)CompilerErrorCode.LowererError, 
                    description:$"unable to find declaration for {parameterSymbol.Name}", 
                    file: location.SourceTree.FilePath, 
                    lineNumber: location.GetLineSpan().StartLinePosition.Line, 
                    columnNumber: location.GetLineSpan().StartLinePosition.Character)
                );
                return EmptyStatement();
            }
        }
    }
}
