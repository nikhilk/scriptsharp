// PreprocessorLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    // #else/#endif/EOL
    internal class PreprocessorLine {

        private PreprocessorTokenType _type;

        public PreprocessorLine(PreprocessorTokenType type) {
            _type = type;
        }

        public PreprocessorTokenType Type {
            get {
                return _type;
            }
        }
    }
}
