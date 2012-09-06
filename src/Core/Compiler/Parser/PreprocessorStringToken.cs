// PreprocessorStringToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class PreprocessorStringToken : PreprocessorToken {

        private string _value;

        public PreprocessorStringToken(string value, BufferPosition position)
            : base(PreprocessorTokenType.String, position) {
            _value = value;
        }

        public string Value {
            get {
                return _value;
            }
        }
    }
}
