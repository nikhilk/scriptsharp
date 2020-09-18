using System.Linq;
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
                    
                    // No longer needed. This should always have a Type which will be stamped by `GenericArgumentRewriter`
                    // GenericTypeArgumentMissing,

                    ScriptIgnoreGenericArgumentsAttributeMissing
                };

        public static IDiagnostic GenericTypeArgumentMissing { get; }
            = new GenericTypeArgumentsMissingDiagnostic();

        public static IDiagnostic ScriptIgnoreGenericArgumentsAttributeMissing { get; }
            = new ScriptIgnoreGenericArgumentsAttributeMissingDiagnostic();
    }
}
