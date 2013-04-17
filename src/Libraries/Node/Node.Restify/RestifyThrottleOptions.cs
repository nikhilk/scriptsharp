// RestifyThrottleOptions.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Restify {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class RestifyThrottleOptions {

        public RestifyThrottleOptions() {
        }

        public RestifyThrottleOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// If available, the amount of requests to burst to
        /// </summary>
        [ScriptField]
        public int Burst {
            set {
            }
        }

        /// <summary>
        /// Do throttling on a /32 (source IP)
        /// </summary>
        [ScriptField]
        public bool Ip {
            set {
            }
        }

        /// <summary>
        /// If using the built-in storage table, the maximum distinct throttling keys to allow at a time
        /// </summary>
        [ScriptField]
        public int MaxKeys {
            set {
            }
        }

        /// <summary>
        /// Per "key" overrides
        /// </summary>
        [ScriptField]
        public object Overrides {
            set {
            }
        }

        [ScriptField]
        public int Rate {
            set {
            }
        }

        /// <summary>
        /// Storage engine; must support put/get
        /// </summary>
        [ScriptField]
        public object TokensTable {
            set {
            }
        }

        /// <summary>
        /// Do throttling on req.username
        /// </summary>
        [ScriptField]
        public bool Username {
            set {
            }
        }

        /// <summary>
        /// Do throttling on a /32 (X-Forwarded-For)
        /// </summary>
        [ScriptField]
        public bool Xff {
            set {
            }
        }
    }
}
