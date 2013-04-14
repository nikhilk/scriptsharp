// HttpServerResponse.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.IO;
using NodeApi.Network;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public class HttpServerResponse : WritableStream, IEventEmitter {

        protected HttpServerResponse() {
        }

        [ScriptField]
        public int StatusCode {
            get;
            set;
        }

        public void AddTrailers(Dictionary<string, string> headers) {
        }

        public string GetHeader(string name) {
            return null;
        }

        public void RemoveHeader(string name) {
        }

        public void SendDate() {
        }

        public void SetHeader(string name, string value) {
        }

        public void WriteContinue() {
        }

        public void WriteHead(HttpStatusCode statusCode) {
        }

        public void WriteHead(HttpStatusCode statusCode, string reasonPhrase) {
        }

        public void WriteHead(HttpStatusCode statusCode, Dictionary<string, string> headers) {
        }

        public void WriteHead(HttpStatusCode statusCode, string reasonPhrase, Dictionary<string, string> headers) {
        }
    }
}
