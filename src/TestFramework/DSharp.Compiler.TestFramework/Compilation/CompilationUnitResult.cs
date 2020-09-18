using System;
using System.Collections.Generic;
using System.Linq;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public class CompilationUnitResult : ICompilationUnitResult
    {
        public string Output { get; }

        public string Metadata { get; }

        public CompilerError[] Errors { get; }

        private CompilationUnitResult(CompilerError[] errors)
        {
            Errors = errors;
        }

        private CompilationUnitResult(string output, string metadata)
        {
            Output = output;
            Metadata = metadata;
            Errors = Array.Empty<CompilerError>();
        }

        public static ICompilationUnitResult CreateErrorResult(IEnumerable<CompilerError> errors)
        {
            return new CompilationUnitResult(errors.ToArray());
        }

        public static ICompilationUnitResult CreateResult(string output, string metadata)
        {
            return new CompilationUnitResult(output, metadata);
        }
    }
}
