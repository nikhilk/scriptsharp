// ErrorEventArgs.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class ErrorEventArgs {

        private Error _error;
        private BufferPosition _position;
        private object[] _args;

        public ErrorEventArgs(Error error, BufferPosition position, params object[] args) {
            _error = error;
            _position = position;
            _args = args;
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

        public BufferPosition Position {
            get {
                return _position;
            }
        }
    }
}
