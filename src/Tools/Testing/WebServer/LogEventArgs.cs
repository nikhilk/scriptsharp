// LogEventArgs.cs
// Script#/Tools/Testing
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace ScriptSharp.Testing {

    internal sealed class LogEventArgs : EventArgs {

        private bool _succeeded;
        private string _log;

        internal LogEventArgs(bool succeeded, string log) {
            _succeeded = succeeded;
            _log = log;
        }

        public string Log {
            get {
                return _log;
            }
        }

        public bool Succeeded {
            get {
                return _succeeded;
            }
        }
    }
}
