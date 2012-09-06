// PreprocessorControlLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    // #error/#warning
    internal sealed class PreprocessorControlLine : PreprocessorLine {

        private string _message;

        public PreprocessorControlLine(PreprocessorTokenType type, string message)
            : base(type) {
            _message = message.Trim();
        }

        public string Message {
            get {
                return _message;
            }
        }
    }
}
