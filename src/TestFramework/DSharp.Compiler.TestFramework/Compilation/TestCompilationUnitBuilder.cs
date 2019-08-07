using System;
using System.Collections.Generic;

namespace DSharp.Compiler.TestFramework.Compilation
{
    internal class TestCompilationUnitBuilder : ICompilationUnitBuilder
    {
        public CompilerOptions Options { get; } = new CompilerOptions
        {
            Defines = new HashSet<string>(),
            Sources = new HashSet<IStreamSource>(),
            Resources = new HashSet<IStreamSource>(),
            References = new HashSet<string>(),
            AssemblyName = $"Test_{Guid.NewGuid()}"
        };

        public ICompilationUnit Build()
        {
            return new TestCompilationUnit(Options);
        }
    }
}
