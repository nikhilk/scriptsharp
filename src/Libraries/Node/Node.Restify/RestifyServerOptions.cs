// RestifyServerOptions.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class RestifyServerOptions {

        public RestifyServerOptions() {
        }

        public RestifyServerOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// If you want to create an HTTPS server, pass in the PEM-encoded certificate and key
        /// </summary>
        public string Certificate;

        /// <summary>
        /// Custom response formatters for res.send()
        /// </summary>
        public object Formatters;

        /// <summary>
        /// If you want to create an HTTPS server, pass in the PEM-encoded certificate and key
        /// </summary>
        public string Key;

        /// <summary>
        /// You can optionally pass in a bunyan (https://github.com/trentm/node-bunyan) instance; not required
        /// </summary>
        public object Log;

        /// <summary>
        /// By default, this will be set in the Server response header, default is restify
        /// </summary>
        public string Name;

        /// <summary>
        /// Any options accepted by node-spdy (https://github.com/indutny/node-spdy)
        /// </summary>
        public string Spdy;

        /// <summary>
        /// Allows you to apply formatting to the value of the header. 
        /// The duration is passed as an argument in number of milliseconds to execute.
        /// </summary>
        /// 
        /// <example>
        ///     app = module.exports = restify.createServer({
        ///             name: 'restify',
        ///             version: '1.0.0',
        ///             responseTimeHeader: 'X-Runtime',
        ///             responseTimeFormatter: function(durationInMilliseconds) {
        ///             return durationInMilliseconds / 1000;
        ///         }
        ///     });
        /// </example>
        public Func<int, string> ResponseTimeFormatter;

        /// <summary>
        /// By default, this will be X-Response-Time
        /// </summary>
        public string ResponseTimeHeader;

        /// <summary>
        /// A default version to set for all routes
        /// </summary>
        public string Version;
    }
}
