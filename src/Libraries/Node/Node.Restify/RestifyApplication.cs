// Restify.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("restify")]
    public static class RestifyApplication {

        public static RestifyChainedHandler[] AcceptParser(string[] serverAcceptable) {
            return null;
        }

        public static RestifyChainedHandler[] AuthorizationParser() {
            return null;
        }

        public static RestifyChainedHandler[] BodyParser() {
            return null;
        }

        public static RestifyChainedHandler[] ConditionalRequest() {
            return null;
        }

        public static RestifyHttpClient CreateHttpClient() {
            return null;
        }

        public static RestifyJsonClient CreateJsonClient() {
            return null;
        }

        public static RestifyJsonClient CreateJsonClient(RestifyJsonClientOptions options) {
            return null;
        }

        public static RestifyServer CreateServer() {
            return null;
        }

        public static RestifyServer CreateServer(RestifyServerOptions rs) {
            return null;
        }

        public static RestifyStringClient CreateStringClient() {
            return null;
        }
        
        public static RestifyChainedHandler[] DateParser() {
            return null;
        }

        public static RestifyChainedHandler[] GZipResponse() {
            return null;
        }

        public static RestifyChainedHandler[] JsonBodyParser() {
            return null;
        }

        public static RestifyChainedHandler[] Jsonp() {
            return null;
        }

        public static RestifyChainedHandler QueryParser() {
            return null;
        }

        public static RestifyChainedHandler[] Throttle(RestifyThrottleOptions options) {
            return null;
        }
    }
}
