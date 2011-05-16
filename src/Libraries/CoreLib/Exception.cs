// Exception.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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

        [IntrinsicProperty]
        public Exception InnerException {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Message {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public object this[string key] {
            get {
                return null;
            }
        }

        [ScriptAlias("Error.createError")]
        public static Exception Create(string message, Dictionary errorInfo) {
            return null;
        }

        [ScriptAlias("Error.createError")]
        public static Exception Create(string message, Dictionary errorInfo, Exception innerException) {
            return null;
        }
    }
}
