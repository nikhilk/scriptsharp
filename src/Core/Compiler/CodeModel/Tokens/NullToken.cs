// NullToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using ScriptSharp.Parser;

namespace ScriptSharp.CodeModel {

    internal sealed class NullToken : LiteralToken {

        internal NullToken(string sourcePath, BufferPosition position)
            : base(LiteralTokenType.Null, sourcePath, position) {
        }

        public override object LiteralValue {
            get {
                return null;
            }
        }

        public object Value {
            get {
                return null;
            }
        }

        public override string ToString() {
            return "null";
        }
    }
}
