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
        public RestifyLogger Log {
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

        /// <summary>
        /// Emitted after a route has finished all the handlers you registered.
        /// You can use this to write audit logs, etc. The route parameter will be the Route object that ran.
        /// Note that when you are using the default 404/405/BadVersion handlers, this event will still be fired,
        /// but route will be null. If you have registered your own listeners for those, this event will not be fired
        /// unless you invoke the cb argument that is provided with them.
        /// </summary>
        [ScriptEvent("on", "removeListener")]
        public event Action After {
            add {
            }
            remove {
            }
        }

        /// <summary>
        /// When a client request is sent for a URL that does exist, but you have not registered a route for that HTTP verb,
        /// restify will emit this event. Note that restify checks for listeners on this event, and if there are none,
        /// responds with a default 405 handler. It is expected that if you listen for this event, you respond to the client.
        /// </summary>
        [ScriptEvent("on", "removeListener")]
        [ScriptName("MethodNotAllowed")]
        public event Action MethodNotAllowed {
            add {
            }
            remove {
            }
        }

        /// <summary>
        /// When a client request is sent for a URL that does not exist, restify will emit this event.
        /// Note that restify checks for listeners on this event, and if there are none, responds with a default 404 handler.
        /// It is expected that if you listen for this event, you respond to the client.
        /// </summary>
        [ScriptEvent("on", "removeListener")]
        [ScriptName("NotFound")]
        public event Action NotFound {
            add {
            }
            remove {
            }
        }

        /// <summary>
        /// Emitted when some handler throws an uncaughtException somewhere in the chain.
        /// The default behavior is to just call res.send(error), and let the built-ins in restify handle transforming,
        /// but you can override to whatever you want here.
        /// </summary>
        [ScriptEvent("on", "removeListener")]
        public event Action UncaughtException {
            add {
            }
            remove {
            }
        }

        /// <summary>
        /// When a client request is sent for a route that exist, but has a content-type mismatch, restify will emit this event.
        /// Note that restify checks for listeners on this event, and if there are none, responds with a default 415 handler.
        /// It is expected that if you listen for this event, you respond to the client.
        /// </summary>
        [ScriptEvent("on", "removeListener")]
        [ScriptName("UnsupportedMediaType")]
        public event Action UnsupportedMediaType {
            add {
            }
            remove {
            }
        }

        /// <summary>
        /// When a client request is sent for a route that exists, but does not match the version(s) on those routes,
        /// restify will emit this event. Note that restify checks for listeners on this event, and if there are none,
        /// responds with a default 400 handler. It is expected that if you listen for this event, you respond to the client.
        /// </summary>
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

        public Dictionary<string, object> Address() {
            return null;
        }

        public RestifyChainedHandler[] AuditLogger(object options) {
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

        public RestifyServer CreateServer(object options) {
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

        public void Get(object options, RestifyChainedHandler handler) {
        }

        public void Get(object options, RestifyChainedHandler[] handlers) {
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

        public RestifyChainedHandler[] RequestLogger(object options) {
            return null;
        }

        public RestifyChainedHandler[] ServeStatic(object options) {
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
