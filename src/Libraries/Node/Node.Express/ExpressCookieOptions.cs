// ExpressCookieOptions.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ExpressCookieOptions {

        public ExpressCookieOptions() {
        }

        public ExpressCookieOptions(params object[] nameValuePairs) {
        }

        [ScriptField]
        public string Domain {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Date Expires {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public bool HttpOnly {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public long MaxAge {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public string Path {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public bool Secure {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public bool Signed {
            get {
                return false;
            }
            set {
            }
        }
    }
}
