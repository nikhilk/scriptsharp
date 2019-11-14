using System.Linq;
using DSharp.CodeAnalysis.Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public class ScriptIgnoreGenericArgumentsAttributeMissingDiagnostic : AbstractDiagnostic
    {
        protected override LocalizableString Title
            => new LocalizableResourceString(nameof(Resources.DSE002AnalyzerTitle), Resources.ResourceManager, typeof(Resources));

        protected override LocalizableString MessageFormat
            => new LocalizableResourceString(nameof(Resources.DSE002AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));

        protected override LocalizableString Description
            => new LocalizableResourceString(nameof(Resources.DSE002AnalyzerDescription), Resources.ResourceManager, typeof(Resources));

        public ScriptIgnoreGenericArgumentsAttributeMissingDiagnostic()
            : base(Consts.ScriptIgnoreGenericArgumentsAttributeMissingId)
        {
        }

        protected override ICodeAnalyzer CreateAnalyzer(DiagnosticDescriptor rule)
        {
            return new Analyzer(this);
        }

        private class Analyzer : AbstractCodeAnalyzer
        {
            public Analyzer(IDiagnostic diagnosticRule) 
                : base(diagnosticRule)
            {
            }

            protected override void AnalyzeSymbol(SymbolAnalysisContext context, ICodeAnalyzerDianosticReporter reporter)
            {
                IMethodSymbol method = context.Symbol as IMethodSymbol;

                if(method == null || !method.IsGenericMethod || !method.HasAttributeWithName(Consts.ScriptIgnoreGenericArgumentsAttribute))
                {
                    return;
                }

                var references = method.DeclaringSyntaxReferences;
                var nodeReference = references.Single();
                MethodDeclarationSyntax methodDeclarationSyntax 
                    = nodeReference.GetSyntax(context.CancellationToken) as MethodDeclarationSyntax;

                var syntaxTree = methodDeclarationSyntax.SyntaxTree;
                var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);

                if (methodDeclarationSyntax != null)
                {
                    GenericMethodInvocationSyntaxWalker walker = new GenericMethodInvocationSyntaxWalker(semanticModel);
                    walker.Visit(methodDeclarationSyntax);

                    foreach (var invocation in walker.FoundInvocations)
                    {
                        if(!invocation.HasScriptIgnoreGenericArgumentsAttribute)
                            reporter.Report(invocation.Node.GetLocation(), invocation.Name.TryGetInferredMemberName());
                    }
                }
            }
        }
    }
}
