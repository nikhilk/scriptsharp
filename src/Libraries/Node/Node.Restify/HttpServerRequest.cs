// HttpServerRequest.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.IO;
using NodeApi.Network;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class HttpServerRequest : ReadableStream, IEventEmitter {

        protected HttpServerRequest() {
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
