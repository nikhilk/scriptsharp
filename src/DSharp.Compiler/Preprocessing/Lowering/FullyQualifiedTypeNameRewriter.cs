using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class FullyQualifiedTypeNameRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;
        private HashSet<string> requiredUsings;

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            requiredUsings = new HashSet<string>();

            var newRoot = Visit(root) as CompilationUnitSyntax;

            var missingUsings = requiredUsings.Where(r => !string.IsNullOrWhiteSpace(r)).Where(r => !root.Usings.Select(u => u.Name.ToString()).Contains(r));

            if (missingUsings.Any())
            {
                var missingDirectives = missingUsings.Select(s => UsingDirective(ParseName(s).WithLeadingTrivia(Whitespace(" "))).WithTrailingTrivia(CarriageReturn)).ToArray();
                newRoot = newRoot.AddUsings(missingDirectives);
            }
            return newRoot;
        }

        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            var type = sem.GetTypeInfo(node).Type 
                ?? sem.GetTypeInfo(node.Parent).Type;

            if(type is INamedTypeSymbol && !node.Parent.IsKind(SyntaxKind.UsingDirective))
            {
                requiredUsings.Add(type.ContainingNamespace.ToString());
                return Visit(node.Right)
                    .WithTriviaFrom(node);
            }

            return node;
        }
    }
}
