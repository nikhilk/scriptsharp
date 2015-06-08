// TestEngine.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Testing {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class TestEngine {

        [ScriptAlias("QUnit.log")]
        public static void Log(string message) {
        }

        [ScriptAlias("QUnit.start")]
        public static void ResumeOnAsyncCompleted() {
        }

        [ScriptAlias("QUnit.triggerEvent")]
        public static void TriggerEvent(object element, string eventName) {
        }

        [ScriptAlias("QUnit.stop")]
        public static void WaitForAsyncCompletion() {
        }

        [ScriptAlias("QUnit.stop")]
        public static void WaitForAsyncCompletion(int timeout) {
        }
    }
}
