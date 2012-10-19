// HttpServerRequest.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class HttpServerRequest : ReadableStream, IEventEmitter {

        private HttpServerRequest() {
        }

        [ScriptField]
        public Socket Connection {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Headers {
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
        public HttpVerb Method {
            get {
                return HttpVerb.GET;
            }
        }

        [ScriptField]
        public object Trailers {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Url {
            get {
                return null;
            }
        }
    }
}
