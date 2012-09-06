// PreprocessorDeclarationLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    // #define/#undef
    internal sealed class PreprocessorDeclarationLine : PreprocessorLine {

        private Name _identifier;

        public PreprocessorDeclarationLine(PreprocessorTokenType type, Name identifier)
            : base(type) {
            _identifier = identifier;
        }

        public Name Identifier {
            get {
                return _identifier;
            }
        }
    }
}
