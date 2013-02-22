// Console.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("console")]
    public static class Console {

        public static void Error(string message) {
        }

        public static void Error(string messageFormat, params object[] args) {
        }

        public static void Log(string message) {
        }

        [ScriptName("dir")]
        public static void Log(string messageFormat, params object[] args) {
        }

        [ScriptName("dir")]
        public static void LogObject(object o) {
        }

        [ScriptName("timeEnd")]
        public static void LogTimeEnd(string label) {
        }

        [ScriptName("time")]
        public static void LogTimeStart(string label) {
        }

        public static void Warn(string message) {
        }

        public static void Warn(string messageFormat, params object[] args) {
        }
    }
}
