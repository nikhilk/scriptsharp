// LiteralToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal abstract class LiteralToken : Token
    {
        internal LiteralToken(LiteralTokenType literalType, string sourcePath, BufferPosition position)
            : base(TokenType.Literal, sourcePath, position)
        {
            LiteralType = literalType;
        }

        public LiteralTokenType LiteralType { get; }

        public abstract object LiteralValue { get; }
    }
}