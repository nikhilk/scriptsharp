// StringToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class StringToken : LiteralToken {

        private string _value;

        internal StringToken(string value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.String, sourcePath, position) {
            _value = value;
        }

        public override object LiteralValue {
            get {
                return Value;
            }
        }

        public string Value {
            get {
                return _value;
            }
        }

        public override string ToString() {
            return "\"" + _value + "\"";
        }
    }
}
