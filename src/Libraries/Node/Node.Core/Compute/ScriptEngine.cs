// ScriptEngine.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Compute {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("vm")]
    [ScriptName("vm")]
    public static class ScriptEngine {

        public static ScriptContext CreateContext() {
            return null;
        }

        public static ScriptContext CreateContext(object global) {
            return null;
        }

        public static ScriptInstance CreateScript(string code) {
            return null;
        }

        public static ScriptInstance CreateScript(string code, string fileName) {
            return null;
        }

        public static object RunInContext(string code, ScriptContext context) {
            return null;
        }

        public static object RunInContext(string code, ScriptContext context, string fileName) {
            return null;
        }

        public static object RunInNewContext(string code) {
            return null;
        }

        public static object RunInNewContext(string code, object global) {
            return null;
        }

        public static object RunInNewContext(string code, object global, string fileName) {
            return null;
        }

        public static object RunInThisContext(string code) {
            return null;
        }

        public static object RunInThisContext(string code, string fileName) {
            return null;
        }
    }
}
