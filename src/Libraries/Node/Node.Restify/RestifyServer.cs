    // RestifyServer.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class RestifyServer {

        private RestifyServer() {
        }

        /// <summary>
        /// list of content-types this server can respond with
        /// </summary>
        [ScriptField]
        public String[] Acceptable {
            get {
                return null;
            }
        }

        /// <summary>
        /// bunyan instance
        /// </summary>
        [ScriptField]
        public BunyanLogger Log {
            get {
                return null;
            }
        }

        /// <summary>
        /// name of the server
        /// </summary>
        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        /// <summary>
        /// Once listen() is called, this will be filled in with where the server is running
        /// </summary>
        [ScriptField]
        public string Url {
            get {
                return null;
            }
        }

        /// <summary>
        /// default version to use in all routes
        /// </summary>
        [ScriptField]
        public string Version {
            get {
                return null;
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action After {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("MethodNotAllowed")]
        public event Action MethodNotAllowed {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("NotFound")]
        public event Action NotFound {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        public event Action UncaughtException {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("UnsupportedMediaType")]
        public event Action UnsupportedMediaType {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("on", "removeListener")]
        [ScriptName("VersionNotAllowed")]
        public event Action VersionNotAllowed {
            add {
            }
            remove {
            }
        }

        public RestifyChainedHandler[] AcceptParser(string[] acceptable) {
            return null;
        }

        public Dictionary Address() {
            return null;
        }

        public RestifyChainedHandler[] AuditLogger(Dictionary options) {
            return null;
        }

        public RestifyChainedHandler[] AuthorizationParser() {
            return null;
        }

        public RestifyChainedHandler[] BodyParser() {
            return null;
        }

        public void Close(Action callback) {
        }

        public RestifyChainedHandler[] ConditionalRequest() {
            return null;
        }
        
        public RestifyServer CreateServer() {
            return null;
        }

        public RestifyServer CreateServer(Dictionary options) {
            return null;
        }

        public RestifyServer CreateServer(RestifyServerOptions options) {
            return null;
        }
        
        public RestifyChainedHandler[] DateParser() {
            return null;
        }

        [ScriptName("del")]
        public void Delete(string path, RestifyChainedHandler handler) {
        }

        [ScriptName("del")]
        public void Delete(string path, RestifyChainedHandler[] handlers) {
        }

        [ScriptName("del")]
        public void Delete(RegExp pathPattern, RestifyChainedHandler handler) {
        }

        [ScriptName("del")]
        public void Delete(RegExp pathPattern, RestifyChainedHandler[] handlers) {
        }

        public void Get(string path, RestifyChainedHandler handler) {
        }

        public void Get(string path, RestifyChainedHandler[] handlers) {
        }

        public void Get(RestifyServerGetOptions options, RestifyChainedHandler handler) {
        }

        public void Get(RestifyServerGetOptions options, RestifyChainedHandler[] handlers) {
        }

        public void Get(RegExp pathPattern, RestifyChainedHandler handler) {
        }

        public void Get(RegExp pathPattern, RestifyChainedHandler[] handlers) {
        }

        public void Get(Dictionary options, RestifyChainedHandler handler) {
        }

        public void Get(Dictionary options, RestifyChainedHandler[] handlers) {
        }

        public RestifyChainedHandler[] GzipResponse() {
            return null;
        }

        public void Head(string path, RestifyChainedHandler handler) {
        }

        public void Head(string path, RestifyChainedHandler[] handlers) {
        }

        public void Head(RegExp pathPattern, RestifyChainedHandler handler) {
        }

        public void Head(RegExp pathPattern, RestifyChainedHandler[] handlers) {
        }

        public void Listen(int port, Action callback) {
        }

        public void Listen(object handle, Action callback) {
        }

        public void Listen(string path, Action callback) {
        }

        public void Post(string path, RestifyChainedHandler handler) {
        }

        public void Post(string path, RestifyChainedHandler[] handlers) {
        }

        public void Post(RegExp pathPattern, RestifyChainedHandler handler) {
        }

        public void Post(RegExp pathPattern, RestifyChainedHandler[] handlers) {
        }

        public void Pre(RestifyChainedHandler handler) {
        }

        public void Pre(RestifyChainedHandler[] handlers) {
        }

        public RestifyChainedHandler[] QueryParser() {
            return null;
        }

        public RestifyChainedHandler[] RequestLogger() {
            return null;
        }

        public RestifyChainedHandler[] RequestLogger(Dictionary options) {
            return null;
        }

        public RestifyChainedHandler[] ServeStatic(Dictionary options) {
            return null;
        }

        public RestifyChainedHandler[] Throttle(RestifyThrottleOptions options) {
            return null;
        }

        public RestifyChainedHandler[] Throttle(Dictionary<string, object> options) {
            return null;
        }

        /// <summary>
        /// Restify runs handlers in the order they are registered on a server, 
        /// so if you want some common handlers to run before any of your routes, 
        /// issue calls to use() before defining routes.
        /// </summary>
        public void Use(RestifyChainedHandler handlers) {
        }

        public void Use(RestifyChainedHandler[] handlers) {
        }
    }
}
