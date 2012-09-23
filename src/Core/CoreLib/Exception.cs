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
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Error")]
    public sealed class Exception {

        public Exception(string message) {
        }

        [ScriptProperty]
        public Exception InnerException {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Message {
            get {
                return null;
            }
        }

        [ScriptProperty]
        [ScriptName("stack")]
        public string StackTrace {
            get {
                return null;
            }
        }

        [ScriptProperty]
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
