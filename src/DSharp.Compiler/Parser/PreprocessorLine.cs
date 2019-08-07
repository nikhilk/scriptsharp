// PreprocessorLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    // #else/#endif/EOL
    internal class PreprocessorLine
    {
        public PreprocessorLine(PreprocessorTokenType type)
        {
            Type = type;
        }

        public PreprocessorTokenType Type { get; }
    }
}