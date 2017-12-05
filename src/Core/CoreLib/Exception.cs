// Exception.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Error type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Error")]
    public class Exception {

        public Exception(string message) {
        }

        [ScriptField]
        public Exception InnerException {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Message {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("stack")]
        public string StackTrace {
            get {
                return null;
            }
        }

        [ScriptField]
        public object this[string key] {
            get {
                return null;
            }
        }

        [ScriptAlias("ss.error")]
        public static Exception Create(string message, Dictionary errorInfo) {
            return null;
        }

        [ScriptAlias("ss.error")]
        public static Exception Create(string message, Dictionary errorInfo, Exception innerException) {
            return null;
        }
    }
}
