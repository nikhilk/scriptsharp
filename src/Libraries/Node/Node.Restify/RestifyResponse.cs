// RestifyResponse.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using NodeApi.Network;

namespace NodeApi.Restify {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class RestifyResponse : HttpServerResponse {

        private RestifyResponse() {
        }

        /// <summary>
        /// In conjunction with contentType, you can explicitly set the charSet to be written in the content-type header
        /// </summary>
        [ScriptField]
        public string CharSet {
            get {
                return String.Empty;
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

        /// <summary>
        /// response headers
        /// </summary>
        [ScriptField]
        public object Headers {
            get {
                return null;
            }
        }

        /// <summary>
        /// HTTP status code
        /// </summary>
        [ScriptName("code")]
        [ScriptField]
        public int HttpStatusCode {
            get {
                return 0;
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
        /// Short-hand for:
        /// res.contentType = 'json';
        /// res.send({hello: 'world'});
        /// </summary>
        /// <param name="code">Status code</param>
        /// <param name="body">content</param>
        public void Json(HttpStatusCode code, Dictionary body) {
        }

        public void Send(string message) {
        }

        public void Send(Dictionary message) {
        }

        public void Send(int errorCode, RestifyError message) {
        }

        /// <summary>
        /// Sets the cache-control header. 
        /// </summary>
        /// <param name="type">type defaults to _public_</param>
        /// <param name="options">options currently only takes maxAge.</param>
        public void SetCache(string type, Dictionary options) {
        }

        /// <summary>
        /// Sets the response statusCode.
        /// </summary>
        /// <param name="code">Status code</param>
        public void Status(HttpStatusCode code) {
        }

        /// <summary>
        /// You can use send() to wrap up all the usual writeHead(), write(), end() calls on the HTTP API of node. 
        /// When you call send(), restify figures out how to format the response (see content-negotiation, above), and does that.
        /// </summary>
        /// <param name="code">Status Code</param>
        /// <param name="body">body can be an Object, a Buffer, or an Error. </param>
        public void Status(HttpStatusCode code, object body) {
        }
    }
}
