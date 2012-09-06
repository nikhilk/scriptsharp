// DecimalToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class DecimalToken : LiteralToken {

        private decimal _value;

        internal DecimalToken(decimal value, string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Decimal, sourcePath, position) {
            _value = value;
        }

        public override object LiteralValue {
            get {
                return Value;
            }
        }

        public decimal Value {
            get {
                return _value;
            }
        }

        public override string ToString() {
            return _value.ToString();
        }
    }
}
