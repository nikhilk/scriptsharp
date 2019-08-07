using System;
using System.Collections.Generic;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.TestFramework.Compilation
{
    internal class TestCompilationUnit : ICompilationUnit, IErrorHandler
    {
        private readonly ScriptCompiler scriptCompiler;
        private readonly CompilerOptions compilerOptions;
        private readonly List<CompilerError> compilationErrors;

        public TestCompilationUnit(CompilerOptions compilerOptions)
        {
            this.compilerOptions = compilerOptions ?? throw new ArgumentNullException(nameof(compilerOptions));
            this.compilerOptions.ScriptFile = new InMemoryStream();
            scriptCompiler = new ScriptCompiler(this);
            compilationErrors = new List<CompilerError>();
        }

        public bool Compile(out ICompilationUnitResult compilationUnitResult)
        {
            bool compilerSuccess = scriptCompiler.Compile(compilerOptions);

            compilationUnitResult = CreateResult(compilerOptions.ScriptFile as InMemoryStream);
            compilationErrors.Clear();

            return compilerSuccess;
        }

        private ICompilationUnitResult CreateResult(InMemoryStream outputStream)
        {
            if (compilationErrors.Count > 0)
            {
                return CompilationUnitResult.CreateErrorResult(compilationErrors);
            }

            return CompilationUnitResult.CreateResult(outputStream.GeneratedOutput);
        }

        void IErrorHandler.ReportError(CompilerError error)
        {
            compilationErrors.Add(error);
        }
    }
}
