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
    public class VarRewriter : CSharpSyntaxRewriter, ILowerer
    {
        const string ANONYMOUS_TYPE_NAME = "__AnonymousType__";

        private readonly IErrorHandler errorHandler;
        private static readonly SymbolDisplayFormat displayFormat = new SymbolDisplayFormat(
                            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
                            miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.UseSpecialTypes
                        );

        private SemanticModel sem;
        private Dictionary<string, string> aliases;
        private HashSet<string> requiredUsings;

        public VarRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            requiredUsings = new HashSet<string>();
            aliases = root.Usings
                .Where(u => u.Alias is NameEqualsSyntax)
                .GroupBy(u => u.Name.ToString())
                .Select(g => g.First())
                .ToDictionary(
                    keySelector: a => a.Name.ToString(),
                    elementSelector: a => a.Alias.ToString()
                );

            var newRoot = Visit(root) as CompilationUnitSyntax;

            var missingUsings = requiredUsings.Where(r => !string.IsNullOrWhiteSpace(r)).Where(r => !root.Usings.Select(u => u.Name.ToString()).Contains(r));

            if (missingUsings.Any())
            {
                var missingDirectives = missingUsings.Select(s => UsingDirective(ParseName(s).WithLeadingTrivia(Whitespace(" ")))).ToArray();
                newRoot = newRoot.AddUsings(missingDirectives);
            }

            return newRoot;
        }

        public override SyntaxNode VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            var typeInfo = sem.GetTypeInfo(node.Type);
            var newNode = (VariableDeclarationSyntax)base.VisitVariableDeclaration(node);

            if (newNode.Type.IsVar)
            {
                string typeName;

                if (typeInfo.Type is INamedTypeSymbol type)
                {
                    if (!aliases.TryGetValue(type.ToString(), out typeName))
                    {
                        typeName = type.ToDisplayString(displayFormat);

                        if (type.IsAnonymousType)
                        {
                            typeName = ANONYMOUS_TYPE_NAME;
                        }

                        requiredUsings.Add(type.ContainingNamespace.Name);

                        if (type.IsGenericType)
                        {
                            foreach (var namespaceName in type.TypeParameters.Select(t => t.ContainingNamespace.Name))
                            {
                                requiredUsings.Add(namespaceName);
                            }
                        }
                    }
                }
                else if (typeInfo.Type is IArrayTypeSymbol arrayType)
                {
                    typeName = arrayType.ToDisplayString(displayFormat);
                }
                else
                {
                    errorHandler.ReportExpressionError($"unable to determine type of var: '{newNode.ToString()}'", newNode);
                    return newNode;
                }

                return newNode.WithType(ParseTypeName(typeName).WithTrailingTrivia(Whitespace(" ")).WithTriviaFrom(newNode.Type));
            }

            return newNode;
        }

        public override SyntaxNode VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            if (sem.GetTypeInfo(node).Type is INamedTypeSymbol type && type.IsAnonymousType)
            {
                var typeName = ANONYMOUS_TYPE_NAME;

                return ObjectCreationExpression(ParseTypeName(typeName).WithLeadingTrivia(Space))
                    .WithInitializer(InitializerExpression(
                        kind: SyntaxKind.ObjectInitializerExpression,
                        openBraceToken: node.OpenBraceToken,
                        expressions: SeparatedList(node.Initializers.Select(MapInitialiser)),
                        closeBraceToken: node.CloseBraceToken))
                    .WithTriviaFrom(node);
            }

            return base.VisitAnonymousObjectCreationExpression(node);
        }

        private ExpressionSyntax MapInitialiser(AnonymousObjectMemberDeclaratorSyntax node)
        {
            return AssignmentExpression(
                kind: SyntaxKind.SimpleAssignmentExpression,
                left: node.NameEquals.Name,
                operatorToken: node.NameEquals.EqualsToken,
                right: node.Expression
            ).WithTriviaFrom(node);
        }
    }
}
