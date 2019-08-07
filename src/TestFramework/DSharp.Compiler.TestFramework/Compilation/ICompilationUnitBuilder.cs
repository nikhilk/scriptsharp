namespace DSharp.Compiler.TestFramework.Compilation
{
    public interface ICompilationUnitBuilder
    {
        CompilerOptions Options { get; }

        ICompilationUnit Build();
    }
}
