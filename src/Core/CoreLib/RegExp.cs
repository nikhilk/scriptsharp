// RegExp.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the RegExp type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("RegExp")]
    public sealed class RegExp {

        public RegExp(string pattern) {
        }

        public RegExp(string pattern, string flags) {
        }

        [ScriptField]
        public int LastIndex {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public bool Global {
            get {
                return false;
            }
        }

        [ScriptField]
        public bool IgnoreCase {
            get {
                return false;
            }
        }

        [ScriptField]
        public bool Multiline {
            get {
                return false;
            }
        }

        [ScriptField]
        public string Pattern {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Source {
            get {
                return null;
            }
        }

        public string[] Exec(string s) {
            return null;
        }

        [ScriptAlias("ss.regexp")]
        public static RegExp Parse(string s) {
            return null;
        }

        public bool Test(string s) {
            return false;
        }
    }
}
