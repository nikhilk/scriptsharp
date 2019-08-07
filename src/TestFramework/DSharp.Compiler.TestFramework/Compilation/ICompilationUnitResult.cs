using DSharp.Compiler.Errors;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public interface ICompilationUnitResult
    {
        string Output { get; }

        CompilerError[] Errors { get; }
    }
}
