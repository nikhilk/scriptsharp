// ErrorStatement.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;

namespace ScriptSharp.ScriptModel {

    internal sealed class ErrorStatement : Statement {

        private string _message;
        private string _location;

        public ErrorStatement(string message, string location)
            : base(StatementType.Error) {
            _message = message;
            _location = location;
        }

        public string Location {
            get {
                return _location;
            }
        }

        public string Message {
            get {
                return _message;
            }
        }
    }
}
