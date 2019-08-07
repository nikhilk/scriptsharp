// PreprocessorStringToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.Parser
{
    internal sealed class PreprocessorStringToken : PreprocessorToken
    {
        public PreprocessorStringToken(string value, BufferPosition position)
            : base(PreprocessorTokenType.String, position)
        {
            Value = value;
        }

        public string Value { get; }
    }
}