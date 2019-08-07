// PreprocessorIntToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class PreprocessorIntToken : PreprocessorToken
    {
        public PreprocessorIntToken(int value, BufferPosition position)
            : base(PreprocessorTokenType.Int, position)
        {
            Value = value;
        }

        public int Value { get; }
    }
}