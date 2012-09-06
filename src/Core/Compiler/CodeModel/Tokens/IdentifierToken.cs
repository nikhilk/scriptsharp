// IdentifierToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class IdentifierToken : Token {

        public const int MaxIdentifierLength = 512;

        private Name _symbol;
        private bool _atPrefixed;

        internal IdentifierToken(Name identifier, bool atPrefixed, string sourcePath, BufferPosition position)
            : base(TokenType.Identifier, sourcePath, position) {
            _symbol = identifier;
            _atPrefixed = atPrefixed;
        }

        public bool AtPrefixed {
            get {
                return _atPrefixed;
            }
        }

        public string Identifier {
            get {
                return _symbol.ToString();
            }
        }

        internal Name Symbol {
            get {
                return _symbol;
            }
        }

        public override string ToString() {
            return _symbol.ToString();
        }
    }
}
