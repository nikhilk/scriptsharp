using DSharp.Compiler.Preprocessing.Lowering;
using Microsoft.CodeAnalysis.CSharp;

namespace DSharp.Compiler.Preprocessing
{
    public static class CompilationPreprocessor
    {
        public static CSharpCompilation Preprocess(CSharpCompilation compilation, params ILowerer[] lowerers)
        {
            for (int i = 0; i < compilation.SyntaxTrees.Length; ++i)
            {
                foreach (var lowerer in lowerers)
                {
                    var syntaxTree = compilation.SyntaxTrees[i];
                    var newRoot = lowerer.Apply(compilation, syntaxTree.GetCompilationUnitRoot());
                    compilation = compilation.ReplaceSyntaxTree(syntaxTree, syntaxTree.WithRootAndOptions(newRoot, syntaxTree.Options));
                }
            }

            return compilation;
        }
    }
}
