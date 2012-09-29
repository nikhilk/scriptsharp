// Url.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("querystring")]
    [ScriptName("querystring")]
    public static class QueryString {

        [ScriptProperty]
        public static Func<string, string> Escape {
            get;
            set;
        }

        [ScriptProperty]
        public static Func<string, string> Unescape {
            get;
            set;
        }

        public static Dictionary<string, string> Parse(string s) {
            return null;
        }

        public static Dictionary<string, string> Parse(string s, string separator) {
            return null;
        }

        public static Dictionary<string, string> Parse(string s, string separator, string equals) {
            return null;
        }

        public static Dictionary<string, string> Parse(string s, string separator, string equals, object options) {
            return null;
        }

        public static string Stringify(Dictionary<string, string> obj) {
            return null;
        }

        public static string Stringify(Dictionary<string, string> obj, string separator) {
            return null;
        }

        public static string Stringify(Dictionary<string, string> obj, string separator, string equals) {
            return null;
        }
    }
}
