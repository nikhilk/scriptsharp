// UIntToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class UIntToken : LiteralToken
    {
        internal UIntToken(uint value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.UInt, sourcePath, position)
        {
            Value = value;
        }

        public override object LiteralValue => Value;

        public uint Value { get; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}