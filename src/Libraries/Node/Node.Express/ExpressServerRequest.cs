// ExpressServerRequest.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class ExpressServerRequest {

        private ExpressServerRequest() {
        }

        [ScriptField]
        public string[] AcceptedCharsets {
            get {
                return null;
            }
        }

        [ScriptField]
        public string[] AcceptedLanguages {
            get {
                return null;
            }
        }

        [ScriptField]
        public Dictionary<string, string> Body {
            get {
                return null;
            }
        }

        [ScriptField]
        public Dictionary<string, string> Cookies {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Host {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("ip")]
        public string IPAddress {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("fresh")]
        public bool IsFresh {
            get {
                return false;
            }
        }

        [ScriptField]
        [ScriptName("stale")]
        public bool IsStale {
            get {
                return false;
            }
        }

        [ScriptField]
        [ScriptName("secure")]
        public bool IsSecure {
            get {
                return false;
            }
        }

        [ScriptField]
        [ScriptName("params")]
        public Dictionary<string, string> Parameters {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Path {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Protocol {
            get {
                return null;
            }
        }

        [ScriptField]
        public string OriginalUrl {
            get {
                return null;
            }
        }

        [ScriptField]
        public Dictionary<string, string> Query {
            get {
                return null;
            }
        }

        [ScriptField]
        public ExpressRoute Route {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Session {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary<string, string> SignedCookies {
            get {
                return null;
            }
        }

        [ScriptField]
        public string[] Subdomains {
            get {
                return null;
            }
        }

        [ScriptField]
        public object User {
            get {
                return null;
            }
        }

        public bool AcceptsCharset(string charset) {
            return false;
        }

        [ScriptName("accepts")]
        public string AcceptsContentType(string type) {
            return null;
        }

        [ScriptName("accepts")]
        public string AcceptsContentType(string[] types) {
            return null;
        }

        public bool AcceptsLanguage(string language) {
            return false;
        }

        [ScriptName("get")]
        public string GetHeader(string name) {
            return null;
        }

        [ScriptName("param")]
        public string GetParameter(string name) {
            return null;
        }

        [ScriptName("is")]
        public string IsContentType(string type) {
            return null;
        }
    }
}
