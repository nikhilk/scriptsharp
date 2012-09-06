// FileErrorEventArgs.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class FileErrorEventArgs {

        private Error _error;
        private FilePosition _position;
        private object[] _args;

        internal FileErrorEventArgs(Error error, FilePosition position, params object[] args) {
            _error = error;
            _position = position;
            _args = args;
        }

        internal FileErrorEventArgs(ErrorEventArgs e, LineMap lineMap)
            : this(e.Error, lineMap.Map(e.Position), e.Args) {
        }

        public object[] Args {
            get {
                return _args;
            }
        }

        public Error Error {
            get {
                return _error;
            }
        }

        public FilePosition Position {
            get {
                return _position;
            }
        }
    }
}
