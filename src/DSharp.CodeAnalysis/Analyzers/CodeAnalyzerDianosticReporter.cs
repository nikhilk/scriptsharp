using System;
using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis.Analyzers
{
    internal class CodeAnalyzerDianosticReporter : ICodeAnalyzerDianosticReporter
    {
        private readonly Action<Diagnostic> diagnosticReporter;
        private readonly IDiagnostic diagnosticRule;

        public CodeAnalyzerDianosticReporter(Action<Diagnostic> diagnosticReporter, IDiagnostic diagnosticRule)
        {
            this.diagnosticReporter = diagnosticReporter;
            this.diagnosticRule = diagnosticRule;
        }

        public void Report(Location location, params string[] messageArguments)
        {
            var diagnostic = Diagnostic.Create(
                    diagnosticRule.Rule,
                    location,
                    messageArguments);

            diagnosticReporter.Invoke(diagnostic);
        }
    }
}