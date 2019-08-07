// IdentifierToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class IdentifierToken : Token
    {
        public const int MAX_IDENTIFIER_LENGTH = 512;

        internal IdentifierToken(Name identifier, bool atPrefixed, string sourcePath, BufferPosition position)
            : base(TokenType.Identifier, sourcePath, position)
        {
            Symbol = identifier;
            AtPrefixed = atPrefixed;
        }

        public bool AtPrefixed { get; }

        public string Identifier => Symbol.ToString();

        internal Name Symbol { get; }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}