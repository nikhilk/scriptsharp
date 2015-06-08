// HttpClientResponse.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class HttpClientResponse : ReadableStream {

        private HttpClientResponse() {
        }

        [ScriptField]
        public Dictionary<string, string> Headers {
            get {
                return null;
            }
        }

        [ScriptField]
        public string HttpVersion {
            get {
                return null;
            }
        }

        [ScriptField]
        public HttpStatusCode StatusCode {
            get {
                return HttpStatusCode.Unknown;
            }
        }

        [ScriptField]
        public Dictionary<string, string> Trailers {
            get {
                return null;
            }
        }
    }
}
