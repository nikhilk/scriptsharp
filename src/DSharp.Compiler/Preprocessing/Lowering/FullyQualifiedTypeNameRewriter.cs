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
        private Dictionary<string, string> typeAliases;

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            requiredUsings = new HashSet<string>();
            typeAliases = new Dictionary<string, string>();

            var newRoot = Visit(root) as CompilationUnitSyntax;

            var missingUsings = requiredUsings.Where(r => !string.IsNullOrWhiteSpace(r)).Where(r => !root.Usings.Select(u => u.Name.ToString()).Contains(r));

            if (missingUsings.Any())
            {
                var missingDirectives = missingUsings.Select(s => UsingDirective(ParseName(s).WithLeadingTrivia(Whitespace(" "))).WithTrailingTrivia(CarriageReturn)).ToArray();
                newRoot = newRoot.AddUsings(missingDirectives);
            }
            if (typeAliases.Any())
            {
                newRoot = newRoot.AddUsings(CreateTypeAliases());
            }

            return newRoot;
        }

        private UsingDirectiveSyntax[] CreateTypeAliases()
        {
            bool isFirstUsing = true;

            return typeAliases.Select(s =>
            {
                var line = UsingDirective(
                    NameEquals(s.Key).WithLeadingTrivia(Whitespace(" ")),
                    ParseName(s.Value)
                ).WithTrailingTrivia(CarriageReturn);

                if (isFirstUsing)
                {
                    isFirstUsing = false;
                    line = line.WithLeadingTrivia(line.GetTrailingTrivia());
                }

                return line;

            }).ToArray();
        }

        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            var type = sem.GetTypeInfo(node).Type 
                ?? sem.GetTypeInfo(node.Parent).Type;
            //todo: find out what is breaking when using alias solution
            if(type is INamedTypeSymbol namedType && !node.Parent.IsKind(SyntaxKind.UsingDirective))
            {
                if(true || namedType.IsGenericType)
                {
                    requiredUsings.Add(type.ContainingNamespace.ToString());
                    return Visit(node.Right)
                        .WithTriviaFrom(node);
                }

                var typeAlias = node.ToString().Replace(".", "_");
                typeAliases[typeAlias] = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted));
                return IdentifierName(typeAlias)
                    .WithTriviaFrom(node);
            }

            return node;
        }
    }
}
