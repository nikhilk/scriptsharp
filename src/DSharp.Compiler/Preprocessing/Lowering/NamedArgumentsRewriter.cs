using System.Linq;
using DSharp.Compiler.Errors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public class NamedArgumentsRewriter : CSharpSyntaxRewriter, ILowerer
    {
        private readonly IErrorHandler errorHandler;
        private SemanticModel sem;

        public NamedArgumentsRewriter(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root)
        {
            sem = compilation.GetSemanticModel(root.SyntaxTree);

            var newRoot = Visit(root) as CompilationUnitSyntax;

            return newRoot;
        }

        public override SyntaxNode VisitArgumentList(ArgumentListSyntax node)
        {
            if (sem.GetSymbolInfo(node.Parent).Symbol is IMethodSymbol methodSymbol)
            {
                if (node.Arguments.Any(a => a.NameColon is NameColonSyntax))
                {
                    var args = methodSymbol.Parameters
                        .Select((p, i) => GetArgumentForParameter(p, i, node))
                        .Where(a => a is ArgumentSyntax);

                    return node.WithArguments(SeparatedList(args));
                }
            }

            return base.VisitArgumentList(node);
        }

        private ArgumentSyntax GetArgumentForParameter(IParameterSymbol parameterSymbol, int index, ArgumentListSyntax node)
        {
            if(node.Arguments.TakeWhile(a => a.NameColon is null).Count() > index)
            {
                return node.Arguments[index];
            }
            else if (node.Arguments.FirstOrDefault(n => n.NameColon?.Name.Identifier.ValueText == parameterSymbol.Name) is ArgumentSyntax argumentSyntax)
            {
                return argumentSyntax.WithNameColon(null);
            }
            else if (parameterSymbol.HasExplicitDefaultValue && GetSyntax(parameterSymbol) is ParameterSyntax parameterSyntax)
            {
                return Argument(parameterSyntax.Default.Value);
            }

            errorHandler.ReportExpressionError($"unable to determine value for named parameter: {parameterSymbol.Name}", node);
            return null;
        }

        private static SyntaxNode GetSyntax(ISymbol parameterSymbol)
        {
            return parameterSymbol.DeclaringSyntaxReferences.FirstOrDefault().GetSyntax();
        }
    }
}
