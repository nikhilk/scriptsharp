// RestifyJsonClientOptions.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class RestifyJsonClientOptions {

        public RestifyJsonClientOptions() {
        }

        public RestifyJsonClientOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Accept header to send
        /// </summary>
        public string Accept;

        /// <summary>
        /// Amount of time to wait for a socket
        /// </summary>
        public int ConnectTimeout;

        /// <summary>
        /// node-dtrace-provider handle
        /// </summary>
        [ScriptName("dtrace")]
        public object DTrace;

        /// <summary>
        /// Will compress data when sent using content-encoding: gzip
        /// </summary>
        public object Gzip;

        /// <summary>
        /// HTTP headers to set in all requests
        /// </summary>
        public object Headers;
        
        /// <summary>
        /// bunyan instance
        /// </summary>
        public object Log;
        
        /// <summary>
        /// options to provide to node-retry; defaults to 3 retries
        /// </summary>
        public object Retry;
        
        /// <summary>
        /// synchronous callback for interposing headers before request is sent
        /// </summary>
        public Action SignRequest;
        
        /// <summary>
        /// Fully-qualified URL to connect to
        /// </summary>
        public string Url;
        
        /// <summary>
        /// user-agent string to use; restify inserts one, but you can override it
        /// </summary>
        public string UserAgent;

        /// <summary>
        /// semver string to set the accept-version
        /// </summary>
        public string Version;
    }
}
