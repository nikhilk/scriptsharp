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

        [ScriptField]
        public string Auth {
            get;
            set;
        }

        [ScriptField]
        public string Hash {
            get;
            set;
        }

        [ScriptField]
        public string Host {
            get;
            set;
        }

        [ScriptField]
        public string HostName {
            get;
            set;
        }

        [ScriptField]
        public string Href {
            get;
            set;
        }

        [ScriptField]
        public string Path {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("pathname")]
        public string PathName {
            get;
            set;
        }

        [ScriptField]
        public string Port {
            get;
            set;
        }

        [ScriptField]
        public string Protocol {
            get;
            set;
        }

        [ScriptField]
        public Dictionary<string, string> Query {
            get;
            set;
        }

        [ScriptField]
        [ScriptName("query")]
        public string QueryString {
            get;
            set;
        }

        [ScriptField]
        public string Search {
            get;
            set;
        }
    }
}
