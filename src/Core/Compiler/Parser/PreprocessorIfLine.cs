// PreprocessorIfLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    // #if/#elif
    internal sealed class PreprocessorIfLine : PreprocessorLine {

        private bool _value;

        public PreprocessorIfLine(PreprocessorTokenType type, bool value)
            : base(type) {
            _value = value;
        }

        public bool Value {
            get {
                return _value;
            }
        }
    }
}
