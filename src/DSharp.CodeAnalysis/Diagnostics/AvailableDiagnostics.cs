using System.Linq;
using DSharp.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis;

namespace DSharp.CodeAnalysis.Diagnostics
{
    public static class AvailableDiagnostics
    {
        public static DiagnosticDescriptor[] Rules
            => RuleDefinitions.Select(def => def.Rule).ToArray();

        public static IDiagnostic[] RuleDefinitions
            => new IDiagnostic[]
                {
                    GenericTypeArgumentMissing,
                    ScriptIgnoreGenericArgumentsAttributeMissing
                };

        public static IDiagnostic GenericTypeArgumentMissing { get; }
            = new GenericTypeArgumentsMissingDiagnostic();

        public static IDiagnostic ScriptIgnoreGenericArgumentsAttributeMissing { get; }
            = new ScriptIgnoreGenericArgumentsAttributeMissingDiagnostic();
    }
}
