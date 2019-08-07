// PreprocessorIdentifierToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class PreprocessorIdentifierToken : PreprocessorToken
    {
        public PreprocessorIdentifierToken(Name value, BufferPosition position)
            : base(PreprocessorTokenType.Identifier, position)
        {
            Value = value;
        }

        public Name Value { get; }
    }
}