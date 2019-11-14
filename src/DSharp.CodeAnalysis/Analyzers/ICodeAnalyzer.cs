using Microsoft.CodeAnalysis.Diagnostics;

namespace DSharp.CodeAnalysis.Analyzers
{
    public interface ICodeAnalyzer
    {
        void ProcessCodeBlock(CodeBlockAnalysisContext context);

        void ProcessSymbol(SymbolAnalysisContext context);
    }
}
