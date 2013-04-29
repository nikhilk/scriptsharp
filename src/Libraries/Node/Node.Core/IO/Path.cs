// Path.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("path")]
    [ScriptName("path")]
    public static class Path {

        [ScriptName("sep")]
        public static string PathSeparator = null;

        [ScriptName("dirname")]
        public static string GetDirectoryName(string path) {
            return null;
        }

        [ScriptName("extname")]
        public static string GetExtension(string path) {
            return null;
        }

        [ScriptName("basename")]
        public static string GetName(string path) {
            return null;
        }

        [ScriptName("basename")]
        public static string GetName(string path, string extensionToStrip) {
            return null;
        }

        public static string Join(params string[] pathParts) {
            return null;
        }

        [ScriptName("relative")]
        public static string MakeRelative(string from, string to) {
            return null;
        }

        public static string Normalize(string path) {
            return null;
        }

        public static string Resolve(string from, string to) {
            return null;
        }
    }
}
