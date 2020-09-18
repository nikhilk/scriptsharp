using System;
using System.Collections.Generic;
using System.Linq;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public static class CompilationUnitResultExtensions
    {
        public static string WriteErrors(this ICompilationUnitResult compilationUnitResult)
        {
            IEnumerable<string> messages = compilationUnitResult.Errors?
                .Select(err => $"({err.LineNumber},{err.ColumnNumber}) {err.Description}")
                .Where(message => !string.IsNullOrWhiteSpace(message)) ?? Array.Empty<string>();
            string errorList = string.Join(", ", messages);
            return $"Compilation Errors: {errorList}";
        }
    }
}
