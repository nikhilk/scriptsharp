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
    public class LambdaRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private static readonly SymbolDisplayFormat namespaceUsingsFormat = SymbolDisplayFormat.FullyQualifiedFormat
            .WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted);

        private readonly IErrorHandler errorHandler;

        private SemanticModel sem;
        private HashSet<string> requiredUsings;

        public LambdaRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);
            requiredUsings = new HashSet<string>();

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

        public override SyntaxNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            var symb = sem.GetSymbolInfo(node).Symbol as IMethodSymbol;
            var newNode = (SimpleLambdaExpressionSyntax)base.VisitSimpleLambdaExpression(node);

            AddUsings(symb.Parameters);

            return AnonymousMethodExpression(
                parameterList: ParameterList(SingletonSeparatedList(FormatParam(node.Parameter, 0, symb))),
                 body: GetFunctionBody(node.Body, newNode.Body)
            );
        }

        private void AddUsings(IEnumerable<IParameterSymbol> paramaters)
        {
            foreach (var type in paramaters.Select(p => p.Type))
            {
                AddUsingForType(type);
            }
        }

        public override SyntaxNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            var symb = sem.GetSymbolInfo(node).Symbol as IMethodSymbol;
            var newNode = (ParenthesizedLambdaExpressionSyntax)base.VisitParenthesizedLambdaExpression(node);

            AddUsings(symb.Parameters);

            var paramSyntax = node.ParameterList.Parameters.Select((p, i) => FormatParam(p, i, symb));
            return AnonymousMethodExpression(
                parameterList: node.ParameterList.WithParameters(SeparatedList(paramSyntax)),
                body: GetFunctionBody(node.Body, newNode.Body)
            );
        }

        private CSharpSyntaxNode GetFunctionBody(CSharpSyntaxNode node, CSharpSyntaxNode newNode)
        {
            if (newNode is ExpressionSyntax expression)
            {
                if (ExpressionHasType((ExpressionSyntax)node))
                {
                    return Block(ReturnStatement(expression.WithLeadingTrivia(Whitespace(" "))));
                }
                else
                {
                    return Block(ExpressionStatement(expression));
                }
            }

            if (newNode is BlockSyntax block)
            {
                return block;
            }

            if (newNode is StatementSyntax statement)
            {
                return Block(statement);
            }

            errorHandler.ReportExpressionError("unable to rewrite lambda body", node);
            return node;
        }

        private bool ExpressionHasType(ExpressionSyntax expression)
        {
            return sem.GetTypeInfo(expression).ConvertedType is ITypeSymbol ts
                && ts.Kind != SymbolKind.ErrorType
                && ts.SpecialType != SpecialType.System_Void;
        }

        private static ParameterSyntax FormatParam(ParameterSyntax p, int i, IMethodSymbol symb)
        {
            var displayFormat = new SymbolDisplayFormat(genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters);
            var typeName = symb.Parameters[i].Type.ToDisplayString(displayFormat);
            return p.WithType(ParseTypeName(typeName).WithTrailingTrivia(Whitespace(" ")));
        }

        private void AddUsingForType(ITypeSymbol type)
        {
            if (type is IArrayTypeSymbol array)
            {
                AddUsingForType(array.ElementType);
            }

            if (type?.ContainingNamespace is INamespaceSymbol ns)
            {
                requiredUsings.Add(ns.ToDisplayString(namespaceUsingsFormat));
            }
        }
    }
}
