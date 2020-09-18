using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class StaticUsingRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;
        private IEnumerable<ITypeSymbol> staticUsingTypes;

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            var staticUsings = root.Usings.Where(IsStatic);
            staticUsingTypes = staticUsings.Select(GetType);

            var newRoot = Visit(root) as CompilationUnitSyntax;

            return newRoot;
        }

        private bool IsStatic(UsingDirectiveSyntax node)
        {
            return node.StaticKeyword != default;
        }

        private ITypeSymbol GetType(UsingDirectiveSyntax node)
        {
            return sem.GetTypeInfo(node.Name).Type;
        }

        public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (IsStatic(node))
            {
                string namespaceName = GetType(node).ContainingNamespace?.Name;

                return UsingDirective(ParseName(namespaceName).WithLeadingTrivia(Whitespace(" "))).WithTriviaFrom(node);
            }

            return base.VisitUsingDirective(node);
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (node.Parent is MemberAccessExpressionSyntax)
            {
                //not static using
                return base.VisitIdentifierName(node);
            }

            var symbol = sem.GetSymbolInfo(node).Symbol as ISymbol;
            var type = symbol?.ContainingType;
            if (staticUsingTypes.Contains(type))
            {
                switch (symbol)
                {
                    case IFieldSymbol _:
                    case IMethodSymbol _:
                    case IPropertySymbol _:
                    case IEventSymbol _:
                        return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ParseTypeName(type.Name), node.WithoutTrivia()).WithTriviaFrom(node);
                }
            }

            return base.VisitIdentifierName(node);
        }
    }
}
