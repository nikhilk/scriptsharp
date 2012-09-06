// PreprocessorIdentifierToken.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class PreprocessorIdentifierToken : PreprocessorToken {

        private Name _value;

        public PreprocessorIdentifierToken(Name value, BufferPosition position)
            : base(PreprocessorTokenType.Identifier, position) {
            _value = value;
        }

        public Name Value {
            get {
                return _value;
            }
        }
    }
}
