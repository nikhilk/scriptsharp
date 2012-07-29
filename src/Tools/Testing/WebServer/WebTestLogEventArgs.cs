// WebTestLogEventArgs.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Testing {

    internal sealed class WebTestLogEventArgs : EventArgs {

        private bool _succeeded;
        private string _log;

        internal WebTestLogEventArgs(bool succeeded, string log) {
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
