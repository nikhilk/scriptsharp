using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis.Analyzers
{
    public interface ICodeAnalyzerDianosticReporter
    {
        void Report(Location location, params string[] messageArguments);
    }
}
