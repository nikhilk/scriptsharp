// LiteralToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal abstract class LiteralToken : Token {

        private LiteralTokenType _literalType;

        internal LiteralToken(LiteralTokenType literalType, string sourcePath, BufferPosition position)
            : base(TokenType.Literal, sourcePath, position) {
            _literalType = literalType;
        }

        public LiteralTokenType LiteralType {
            get {
                return _literalType;
            }
        }

        public abstract object LiteralValue {
            get;
        }
    }
}
