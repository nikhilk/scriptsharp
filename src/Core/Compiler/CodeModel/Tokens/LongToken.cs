// LongToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class LongToken : LiteralToken {

        private long _value;

        internal LongToken(long value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Long, sourcePath, position) {
            _value = value;
        }

        public override object LiteralValue {
            get {
                return Value;
            }
        }

        public long Value {
            get {
                return _value;
            }
        }

        public override string ToString() {
            return _value.ToString();
        }
    }
}
