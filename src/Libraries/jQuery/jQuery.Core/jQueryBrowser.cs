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
    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryBrowser {

        private jQueryBrowser() {
        }

        /// <summary>
        /// Gets whether the current browser is Opera.
        /// </summary>
        [ScriptProperty]
        public bool Opera {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is a Mozilla-based browser.
        /// </summary>
        [ScriptProperty]
        public bool Mozilla {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is Microsoft Internet Explorer.
        /// </summary>
        [ScriptProperty]
        [ScriptName("msie")]
        public bool MSIE {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets whether the current browser is Safari.
        /// </summary>
        [ScriptProperty]
        public bool Safari {
            get {
                return true;
            }
        }

        /// <summary>
        /// Gets the browser version information.
        /// </summary>
        [ScriptProperty]
        public string Version {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets whether the current browser is WebKit-based.
        /// </summary>
        [ScriptProperty]
        [ScriptName("webkit")]
        public bool WebKit {
            get {
                return true;
            }
        }
    }
}
