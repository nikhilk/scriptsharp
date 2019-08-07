// NullToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class NullToken : LiteralToken
    {
        internal NullToken(string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Null, sourcePath, position)
        {
        }

        public override object LiteralValue => null;

        public object Value => null;

        public override string ToString()
        {
            return "null";
        }
    }
}