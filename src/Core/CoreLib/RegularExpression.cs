// RegularExpression.cs
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
    public sealed class RegularExpression {

        public RegularExpression(string pattern) {
        }

        public RegularExpression(string pattern, string flags) {
        }

        [ScriptProperty]
        public int LastIndex {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool Global {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public bool IgnoreCase {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public bool Multiline {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public string Pattern {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string Source {
            get {
                return null;
            }
        }

        public string[] Exec(string s) {
            return null;
        }

        [ScriptAlias("ss.regexp")]
        public static RegularExpression Parse(string s) {
            return null;
        }

        public bool Test(string s) {
            return false;
        }
    }
}
