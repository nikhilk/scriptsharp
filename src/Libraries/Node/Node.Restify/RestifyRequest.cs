// RestifyRequest.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.Network;

namespace NodeApi.Restify {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class RestifyRequest : HttpServerRequest {

        private RestifyRequest() {
        }

        /// <summary>
        /// short hand for the header content-length
        /// </summary>
        [ScriptField]
        public int ContentLength {
            get {
                return 0;
            }
        }

        /// <summary>
        /// short hand for the header content-type
        /// </summary>
        [ScriptField]
        public string ContentType {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// url.parse(req.url) href
        /// </summary>
        [ScriptField]
        public string Href {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// A unique request id (x-request-id)
        /// </summary>
        [ScriptField]
        public string Id {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// bunyan logger you can piggyback on
        /// </summary>
        [ScriptField]
        public BunyanLogger Log {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("params")]
        public Dictionary<string, string> Parameters {
            get {
                return null;
            }
        }

        /// <summary>
        /// cleaned up URL path
        /// </summary>
        [ScriptField]
        public string Path {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// the query string only
        /// </summary>
        [ScriptField]
        public string Query {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// Whether this was an SSL request
        /// </summary>
        [ScriptField]
        public bool Secure {
            get {
                return true;
            }
        }

        /// <summary>
        /// the time when this request arrived (ms since epoch)
        /// </summary>
        [ScriptField]
        [ScriptName("time")]
        public int TimeInMs {
            get {
                return 0;
            }
        }

        [ScriptName("accepts")]
        public string AcceptsContentType(string type) {
            return null;
        }

        [ScriptName("accepts")]
        public string AcceptsContentType(string[] types) {
            return null;
        }

        [ScriptName("header")]
        public string GetHeader(string name) {
            return String.Empty;
        }

        [ScriptName("header")]
        public string GetHeader(string key, string defaultValue) {
            return String.Empty;
        }

        public BunyanLogger GetLogger(string name) {
            return null;
        }

        [ScriptName("is")]
        public string IsContentType(string type) {
            return null;
        }
    }
}
