// Http.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NodeApi.Network {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("http")]
    [ScriptName("http")]
    public static class Http {

        [ScriptField]
        [ScriptName("STATUS_CODES")]
        public static HttpStatus StatusCodes {
            get {
                return null;
            }
        }

        public static HttpServer CreateServer() {
            return null;
        }

        public static HttpServer CreateServer(HttpListener listener) {
            return null;
        }

        public static HttpClientRequest Get(string url, Action<HttpClientResponse> responseCallback) {
            return null;
        }

        public static HttpClientRequest Get(HttpClientOptions options, Action<HttpClientResponse> responseCallback) {
            return null;
        }

        public static HttpClientRequest Request(string url, Action<HttpClientResponse> responseCallback) {
            return null;
        }

        public static HttpClientRequest Request(HttpClientOptions options, Action<HttpClientResponse> responseCallback) {
            return null;
        }
    }
}
