using System.Linq;
using DSharp.CodeAnalysis.Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public class GenericTypeArgumentsMissingDiagnostic : AbstractDiagnostic
    {
        protected override LocalizableString Title
            => new LocalizableResourceString(nameof(Resources.DSE001AnalyzerTitle), Resources.ResourceManager, typeof(Resources));

        protected override LocalizableString MessageFormat
            => new LocalizableResourceString(nameof(Resources.DSE001AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));

        protected override LocalizableString Description
            => new LocalizableResourceString(nameof(Resources.DSE001AnalyzerDescription), Resources.ResourceManager, typeof(Resources));

        public GenericTypeArgumentsMissingDiagnostic()
            : base(Consts.GenericTypeArgumentsMissingId)
        {
        }

        protected override ICodeAnalyzer CreateAnalyzer(DiagnosticDescriptor rule)
        {
            return new CodeAnalyzer(this);
        }

        private class CodeAnalyzer : AbstractCodeAnalyzer
        {
            public CodeAnalyzer(IDiagnostic diagnosticRule)
                : base(diagnosticRule)
            {
            }

            protected override void AnalyzeCodeBlock(CodeBlockAnalysisContext context, ICodeAnalyzerDianosticReporter reporter)
            {
                GenericMethodInvocationSyntaxWalker missingTypeArgumentSyntaxWalker = new GenericMethodInvocationSyntaxWalker(context.SemanticModel);
                missingTypeArgumentSyntaxWalker.Visit(context.CodeBlock);

                foreach (var invocation in missingTypeArgumentSyntaxWalker.FoundInvocations)
                {
                    if(!(invocation.Name is GenericNameSyntax) && !invocation.HasScriptIgnoreGenericArgumentsAttribute)
                        reporter.Report(invocation.Node.GetLocation(), invocation.Name.TryGetInferredMemberName());
                }
            }
        }
    }
}
