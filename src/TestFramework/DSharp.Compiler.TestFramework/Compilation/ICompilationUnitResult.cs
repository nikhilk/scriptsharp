using System.Collections.Generic;
using DSharp.Compiler.Errors;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public interface ICompilationUnitResult
    {
        string Output { get; }

        string Metadata { get; }

        CompilerError[] Errors { get; }
    }
}
