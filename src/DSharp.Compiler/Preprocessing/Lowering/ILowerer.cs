using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DSharp.Compiler.Preprocessing.Lowering
{
    public interface ILowerer
    {
        CompilationUnitSyntax Apply(Compilation compilation, CompilationUnitSyntax root);
    }
}
