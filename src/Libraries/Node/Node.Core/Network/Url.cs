// Url.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("url")]
    [ScriptName("URL")]
    public static class Url {

        public static string Format(UrlData urlData) {
            return null;
        }

        public static UrlData Parse(string url) {
            return null;
        }

        public static UrlData Parse(string url, bool parseQueryString) {
            return null;
        }

        public static UrlData Parse(string url, bool parseQueryString, bool slashesDenoteHost) {
            return null;
        }

        public static string Resolve(string from, string to) {
            return null;
        }
    }
}
