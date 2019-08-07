// CommentTokenType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel.Tokens
{
    internal sealed class CommentToken : Token
    {
        internal CommentToken(CommentTokenType type, string comment, string sourcePath, BufferPosition position)
            : base(TokenType.Comment, sourcePath, position)
        {
            CommentType = type;
            Comment = comment;
        }

        public string Comment { get; }

        public CommentTokenType CommentType { get; }
    }
}