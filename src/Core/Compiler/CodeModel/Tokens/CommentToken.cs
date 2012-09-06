// CommentTokenType.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class CommentToken : Token {

        private string _comment;
        private CommentTokenType _commentType;

        internal CommentToken(CommentTokenType type, string comment, string sourcePath, BufferPosition position)
            : base(TokenType.Comment, sourcePath, position) {
            _commentType = type;
            _comment = comment;
        }

        public string Comment {
            get {
                return _comment;
            }
        }

        public CommentTokenType CommentType {
            get {
                return _commentType;
            }
        }
    }
}
