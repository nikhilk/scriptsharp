// PreprocessorIntToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class PreprocessorIntToken : PreprocessorToken {

        private int _value;

        public PreprocessorIntToken(int value, BufferPosition position)
            : base(PreprocessorTokenType.Int, position) {
            _value = value;
        }

        public int Value {
            get {
                return _value;
            }
        }
    }
}
