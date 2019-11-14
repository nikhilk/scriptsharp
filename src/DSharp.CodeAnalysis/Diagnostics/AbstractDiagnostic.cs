using DSharp.CodeAnalysis.Analyzers;
using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public abstract class AbstractDiagnostic : IDiagnostic
    {
        public string DiagnosticId { get; }

        public DiagnosticDescriptor Rule { get; }

        public ICodeAnalyzer Analyzer { get; }

        protected abstract LocalizableString Title { get; }

        protected abstract LocalizableString MessageFormat { get; }

        protected abstract LocalizableString Description { get; }

        public AbstractDiagnostic(string diagnosticId)
        {
            this.DiagnosticId = diagnosticId;
            Rule = CreateRule();
            Analyzer = CreateAnalyzer(Rule);
        }

        private DiagnosticDescriptor CreateRule()
        {
            return new DiagnosticDescriptor(
                DiagnosticId,
                Title,
                MessageFormat,
                Consts.Category,
                DiagnosticSeverity.Error,
                isEnabledByDefault: true,
                description: Description);
        }

        protected abstract ICodeAnalyzer CreateAnalyzer(DiagnosticDescriptor rule);
    }
}
