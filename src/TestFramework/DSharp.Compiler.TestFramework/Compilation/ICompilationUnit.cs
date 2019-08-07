namespace DSharp.Compiler.TestFramework.Compilation
{
    public interface ICompilationUnit
    {
        bool Compile(out ICompilationUnitResult result);
    }
}
