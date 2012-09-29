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
    [ScriptName("Object")]
    public sealed class UrlData {

        public UrlData() {
        }

        public UrlData(params object[] nameValuePairs) {
        }

        [ScriptProperty]
        public string Auth {
            get;
            set;
        }

        [ScriptProperty]
        public string Hash {
            get;
            set;
        }

        [ScriptProperty]
        public string Host {
            get;
            set;
        }

        [ScriptProperty]
        public string HostName {
            get;
            set;
        }

        [ScriptProperty]
        public string Href {
            get;
            set;
        }

        [ScriptProperty]
        public string Path {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("pathname")]
        public string PathName {
            get;
            set;
        }

        [ScriptProperty]
        public string Port {
            get;
            set;
        }

        [ScriptProperty]
        public string Protocol {
            get;
            set;
        }

        [ScriptProperty]
        public Dictionary<string, string> Query {
            get;
            set;
        }

        [ScriptProperty]
        [ScriptName("query")]
        public string QueryString {
            get;
            set;
        }

        [ScriptProperty]
        public string Search {
            get;
            set;
        }
    }
}
