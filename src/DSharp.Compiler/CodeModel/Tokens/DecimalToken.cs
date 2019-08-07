// DecimalToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class DecimalToken : LiteralToken
    {
        internal DecimalToken(decimal value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Decimal, sourcePath, position)
        {
            Value = value;
        }

        public override object LiteralValue => Value;

        public decimal Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}