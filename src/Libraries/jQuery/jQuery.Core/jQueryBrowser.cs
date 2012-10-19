// jQueryBrowser.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Provides information about the current browser.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class jQueryBrowser {

        private jQueryBrowser() {
        }

        /// <summary>
        /// Gets whether the current browser is Opera.
        /// </summary>
        [ScriptField]
        public bool Opera {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is a Mozilla-based browser.
        /// </summary>
        [ScriptField]
        public bool Mozilla {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is Microsoft Internet Explorer.
        /// </summary>
        [ScriptField]
        [ScriptName("msie")]
        public bool MSIE {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is Safari.
        /// </summary>
        [ScriptField]
        public bool Safari {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets the browser version information.
        /// </summary>
        [ScriptField]
        public string Version {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets whether the current browser is WebKit-based.
        /// </summary>
        [ScriptField]
        [ScriptName("webkit")]
        public bool WebKit {
            get {
                return true;
            }
        }
    }
}
