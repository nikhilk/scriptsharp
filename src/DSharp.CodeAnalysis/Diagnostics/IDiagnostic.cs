using DSharp.CodeAnalysis.Analyzers;
using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public interface IDiagnostic
    {
        string DiagnosticId { get; }

        ICodeAnalyzer Analyzer { get; }

        DiagnosticDescriptor Rule { get; }
    }
}
