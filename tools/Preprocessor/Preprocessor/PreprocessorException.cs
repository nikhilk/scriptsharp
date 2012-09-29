// PreprocessorException.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Preprocessor {

    internal sealed class PreprocessorException : Exception {

        private int _line;
        private string _sourceFile;
        private string _sourceCode;

        public PreprocessorException(string message, string sourceCode, string sourceFile, int line)
            : base(message) {
            _sourceFile = sourceFile;
            _line = line;
            _sourceCode = sourceCode;
        }

        public PreprocessorException(string message, Exception innerException, string sourceCode, string sourceFile, int line)
            : base(message, innerException) {
            _sourceFile = sourceFile;
            _line = line;
            _sourceCode = sourceCode;
        }

        public int Line {
            get {
                return _line;
            }
        }

        public string SourceCode {
            get {
                return _sourceCode;
            }
        }

        public string SourceFile {
            get {
                return _sourceFile;
            }
        }
    }
}
