// FloatToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class FloatToken : LiteralToken
    {
        internal FloatToken(float value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Float, sourcePath, position)
        {
            Value = value;
        }

        public override object LiteralValue => Value;

        public float Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}