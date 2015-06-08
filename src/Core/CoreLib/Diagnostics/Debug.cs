// Debug.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Diagnostics {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("console")]
    public static class Debug {

        [Conditional("DEBUG")]
        public static void Assert(bool condition) {
        }

        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message) {
        }

        [Conditional("DEBUG")]
        [ScriptAlias("ss.fail")]
        public static void Fail(string message) {
        }

        [Conditional("DEBUG")]
        [ScriptName("log")]
        public static void WriteLine(string message) {
        }
    }
}
