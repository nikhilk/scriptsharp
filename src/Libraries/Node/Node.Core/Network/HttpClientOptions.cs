// HttpClientOptions.cs
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
    public sealed class HttpClientOptions {

        public HttpClientOptions() {
        }

        public HttpClientOptions(object[] nameValuePairs) {
        }

        [ScriptField]
        [ScriptName("auth")]
        public string Credentials {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary<string, string> Headers {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName("hostname")]
        public string HostName {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public HttpVerb Method {
            get {
                return HttpVerb.GET;
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
        public int Port {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
