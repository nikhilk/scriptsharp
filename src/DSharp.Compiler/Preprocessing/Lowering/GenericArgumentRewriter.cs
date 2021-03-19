using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.CodeModel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class GenericArgumentRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private static readonly SymbolDisplayFormat displayFormat = new SymbolDisplayFormat(
                    genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                    typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
                    miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable | SymbolDisplayMiscellaneousOptions.UseSpecialTypes,
                    extensionMethodStyle: SymbolDisplayExtensionMethodStyle.StaticMethod
                );
        private static readonly SymbolDisplayFormat namespaceUsingsFormat = SymbolDisplayFormat.FullyQualifiedFormat
            .WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted);

        private SemanticModel semanticModel;
        private HashSet<string> requiredUsings = new HashSet<string>();

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            semanticModel = compilation.GetSemanticModel(root.SyntaxTree);

            var newRoot = Visit(root) as CompilationUnitSyntax;
            var missingUsings = requiredUsings.Where(r => !root.Usings.Select(u => u.Name.ToString()).Contains(r));

            if (missingUsings.Any())
            {
                var missingDirectives = missingUsings.Select(s => UsingDirective(ParseName(s).WithLeadingTrivia(Whitespace(" ")))).ToArray();
                missingDirectives[missingDirectives.Length - 1] = missingDirectives.Last().WithTrailingTrivia(EndOfLine(Environment.NewLine));
                newRoot = newRoot.AddUsings(missingDirectives);
            }

            return newRoot;
        }

        public TypeSyntax UseType(ITypeSymbol type)
        {
            AddUsingForType(type);
            return IdentifierName(type.ToDisplayString());
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            var symbol = Try(() => GetMethodSymbol(node), null);
            var methodSymbol = symbol as IMethodSymbol;

            if (methodSymbol == null
                || !methodSymbol.IsGenericMethod)
            {
                return base.VisitIdentifierName(node);
            }

            AddUsingForType(methodSymbol.ContainingType);

            foreach (var typeArgument in methodSymbol.TypeArguments)
            {
                AddUsingForType(typeArgument);
            }

            AddUsingForType(methodSymbol.ReturnType);

            var fullName = methodSymbol.ToDisplayString(displayFormat);

            return ParseExpression(fullName);
        }

        private ISymbol GetMethodSymbol(ExpressionSyntax node)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(node);

            return symbolInfo.Symbol
                ?? symbolInfo.CandidateSymbols
                    .SingleOrDefault(s => s is IMethodSymbol m
                        && m.TypeArguments.Count(a => a is ITypeParameterSymbol) == 0);
        }

        private void AddUsingForType(ITypeSymbol type)
        {
            if(type is IArrayTypeSymbol array)
            {
                AddUsingForType(array.ElementType);
            }

            if (type.ContainingNamespace is INamespaceSymbol ns)
            {
                requiredUsings.Add(ns.ToDisplayString(namespaceUsingsFormat));
            }
        }

        private static T Try<T>(Func<T> action, T defaultValue)
        {
            try { return action(); }
            catch (Exception) { }

            return defaultValue;
        }
    }
}
