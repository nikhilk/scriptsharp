using System.Collections.Immutable;
using System.Diagnostics;
using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DSharp.CodeAnalysis
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DSharpAnalyzer : DiagnosticAnalyzer
    {
        private readonly DiagnosticDescriptor[] rules;

        public DSharpAnalyzer()
        {
            this.rules = AvailableDiagnostics.Rules;
        }

        public DSharpAnalyzer(params DiagnosticDescriptor[] rules)
        {
            this.rules = rules;
            if(rules.Length == 0)
                this.rules = AvailableDiagnostics.Rules;
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
            => ImmutableArray.Create(rules);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);

            context.RegisterCodeBlockAction(AnalyzeCodeBlock);
            context.RegisterSymbolAction(AnalyzeMethodSymbol, SymbolKind.Method);
        }

        //TODO: Look at cleaning this up and making it easier to register processors and fixers etc.
        private void AnalyzeCodeBlock(CodeBlockAnalysisContext context)
        {
            if (this.SupportedDiagnostics.Contains(AvailableDiagnostics.GenericTypeArgumentMissing.Rule))
                AvailableDiagnostics.GenericTypeArgumentMissing.Analyzer.ProcessCodeBlock(context);
        }

        //TODO: Look at cleaning this up and making it easier to register processors and fixers etc.
        private void AnalyzeMethodSymbol(SymbolAnalysisContext context)
        {
            if (this.SupportedDiagnostics.Contains(AvailableDiagnostics.ScriptIgnoreGenericArgumentsAttributeMissing.Rule))
                AvailableDiagnostics.ScriptIgnoreGenericArgumentsAttributeMissing.Analyzer.ProcessSymbol(context);
        }
    }
}
