// PreprocessorLineNumberLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    // #line
    internal sealed class PreprocessorLineNumberLine : PreprocessorLine
    {
        public PreprocessorLineNumberLine(int line)
            : base(PreprocessorTokenType.Line)
        {
            Line = line;
        }

        public PreprocessorLineNumberLine(int line, string file)
            : this(line)
        {
            File = file;
        }

        public string File { get; }

        public int Line { get; }
    }
}