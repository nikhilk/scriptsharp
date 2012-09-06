// PreprocessorLineNumberLine.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    // #line
    internal sealed class PreprocessorLineNumberLine : PreprocessorLine {

        private int _line;
        private string _file;

        public PreprocessorLineNumberLine(int line)
            : base(PreprocessorTokenType.Line) {
            _line = line;
        }

        public PreprocessorLineNumberLine(int line, string file)
            : this(line) {
            _file = file;
        }

        public string File {
            get {
                return _file;
            }
        }

        public int Line {
            get {
                return _line;
            }
        }
    }
}
