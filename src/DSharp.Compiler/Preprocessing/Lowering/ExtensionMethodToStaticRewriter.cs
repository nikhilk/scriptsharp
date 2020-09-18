using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class ExtensionMethodToStaticRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private SemanticModel sem;
        private Dictionary<string, string> typeAliases = new Dictionary<string, string>();

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            var newRoot = Visit(root) as CompilationUnitSyntax;

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

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symb = Try(() => sem.GetSymbolInfo(node).Symbol as IMethodSymbol, null);
            var newNode = (InvocationExpressionSyntax)base.VisitInvocationExpression(node);

            if (symb != null
                && symb.IsExtensionMethod
                && symb.ReceiverType != symb.ContainingSymbol) // ignore extension methods invoked as static methods
            {
                var extensionClass = symb.ContainingSymbol.ToDisplayString();
                var extensionAlias = extensionClass.Replace(".", "_");

                if (!typeAliases.ContainsKey(extensionAlias))
                {
                    typeAliases.Add(extensionAlias, extensionClass);
                }

                switch (newNode.Expression)
                {
                    case MemberAccessExpressionSyntax memberExpression:
                        {
                            var newArguments = ArgumentList();
                            newArguments = newArguments.AddArguments(Argument(memberExpression.Expression.WithoutTrivia())); // extension method target
                            newArguments = newArguments.AddArguments(newNode.ArgumentList.Arguments.ToArray());

                            return InvocationExpression(
                                MemberAccessExpression(
                                    memberExpression.Kind(),
                                    IdentifierName(extensionAlias),
                                    memberExpression.OperatorToken,
                                    memberExpression.Name),
                                newArguments)
                                .WithLeadingTrivia(newNode.GetLeadingTrivia())
                                .WithTrailingTrivia(newNode.GetTrailingTrivia());
                        }

                    case SimpleNameSyntax nameExpression:
                        {
                            return InvocationExpression(
                                MemberAccessExpression(
                                    SyntaxKind.SimpleMemberAccessExpression,
                                    IdentifierName(extensionAlias),
                                    nameExpression.WithoutTrivia()),
                                newNode.ArgumentList)
                                .WithLeadingTrivia(newNode.GetLeadingTrivia())
                                .WithTrailingTrivia(newNode.GetTrailingTrivia());
                        }

                    default:
                        throw new NotImplementedException(); // please implement extra cases!
                }
            }

            return newNode;
        }

        private static T Try<T>(Func<T> action, T defaultValue)
        {
            try { return action(); }
            catch (Exception) { }

            return defaultValue;
        }
    }
}
