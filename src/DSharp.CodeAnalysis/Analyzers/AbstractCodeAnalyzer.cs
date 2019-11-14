using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DSharp.CodeAnalysis.Analyzers
{
    public abstract class AbstractCodeAnalyzer : ICodeAnalyzer
    {
        private readonly IDiagnostic diagnosticRule;

        public AbstractCodeAnalyzer(IDiagnostic diagnosticRule)
        {
            this.diagnosticRule = diagnosticRule;
        }

        public void ProcessCodeBlock(CodeBlockAnalysisContext context)
        {
            ICodeAnalyzerDianosticReporter reporter = new CodeAnalyzerDianosticReporter(context.ReportDiagnostic, diagnosticRule);
            AnalyzeCodeBlock(context, reporter);
        }

        //TODO: Make this a subscription based API, where you register the symbol type you want to test and it registerd to the correct calls
        public void ProcessSymbol(SymbolAnalysisContext context)
        {
            ICodeAnalyzerDianosticReporter reporter = new CodeAnalyzerDianosticReporter(context.ReportDiagnostic, diagnosticRule);
            AnalyzeSymbol(context, reporter);
        }

        protected virtual void AnalyzeCodeBlock(CodeBlockAnalysisContext context, ICodeAnalyzerDianosticReporter reporter)
        {
        }

        protected virtual void AnalyzeSymbol(SymbolAnalysisContext context, ICodeAnalyzerDianosticReporter reporter)
        {
        }
    }
}
