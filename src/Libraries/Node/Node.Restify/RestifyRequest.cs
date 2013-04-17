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
    public sealed class RestifyRequest {

        private RestifyRequest() {
        }

        [ScriptField]
        public Socket Connection {
            get {
                return null;
            }
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

        [ScriptField]
        public object Headers {
            get {
                return null;
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

        [ScriptField]
        public string HttpVersion {
            get {
                return null;
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
        public RestifyLogger Log {
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
        public int TimeInMilliseconds {
            get {
                return 0;
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

        /// <summary>
        /// Check if the Accept header is present, and includes the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [ScriptName("accepts")]
        public bool AcceptsContentType(string type) {
            return true;
        }

        /// <summary>
        /// Check if the Accept header is present, and includes the given types.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        [ScriptName("accepts")]
        public bool AcceptsContentType(string[] types) {
            return true;
        }

        [ScriptName("header")]
        public string GetHeader(string name) {
            return String.Empty;
        }

        [ScriptName("header")]
        public string GetHeader(string key, string defaultValue) {
            return String.Empty;
        }

        /// <summary>
        /// Shorthand to grab a new bunyan instance that is a child component of the one restify has:
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RestifyLogger GetLogger(string name) {
            return null;
        }

        /// <summary>
        /// Check if the incoming request contains the Content-Type header field, and it contains the give mime type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [ScriptName("is")]
        public bool IsContentType(string type) {
            return true;
        }
    }
}
