// WebTestResult.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Testing {

    public sealed class WebTestResult {

        private bool _succeeded;
        private bool _timedOut;
        private string _log;

        internal WebTestResult() {
            _timedOut = true;
        }

        internal WebTestResult(bool succeeded, string log) {
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

        public bool TimedOut {
            get {
                return _timedOut;
            }
        }
    }
}
