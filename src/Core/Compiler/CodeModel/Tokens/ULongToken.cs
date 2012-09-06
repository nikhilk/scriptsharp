// ULongToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class ULongToken : LiteralToken {

        private ulong _value;

        internal ULongToken(ulong value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.ULong, sourcePath, position) {
            _value = value;
        }

        public override object LiteralValue {
            get {
                return Value;
            }
        }

        public ulong Value {
            get {
                return _value;
            }
        }

        public override string ToString() {
            return _value.ToString();
        }
    }
}
