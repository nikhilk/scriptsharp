// PreprocessorIfLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    // #if/#elif
    internal sealed class PreprocessorIfLine : PreprocessorLine
    {
        public PreprocessorIfLine(PreprocessorTokenType type, bool value)
            : base(type)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}