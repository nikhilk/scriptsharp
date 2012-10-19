// Navigator.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html.Services;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Navigator {

        private Navigator() {
        }

        /// <summary>
        /// Returns the name of the browser.
        /// </summary>
        [ScriptField]
        public string AppName {
            get {
                return null;
            }
        }

        /// <summary>
        /// Returns the version of the browser.
        /// </summary>
        [ScriptField]
        public string AppVersion {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the current language (applies to IE and Opera).
        /// </summary>
        [ScriptField]
        public string BrowserLanguage {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool CookieEnabled {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns a string representing the language of the browser (applies to Gecko, Opera, and WebKit).
        /// </summary>
        [ScriptField]
        public string Language {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the default language used by the operating system (applies to IE).
        /// </summary>
        [ScriptField]
        public string SystemLanguage {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the operating system's natural language setting (applies to IE and Opera).
        /// </summary>
        [ScriptField]
        public string UserLanguage {
            get {
                return null;
            }
        }

        [ScriptField]
        public GeolocationService Geolocation {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool OnLine {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns the name of the platform.
        /// </summary>
        [ScriptField]
        public string Platform {
            get {
                return null;
            }
        }

        /// <summary>
        /// Returns a PluginArray object, listing the plugins installed in the application.
        /// </summary>
        [ScriptField]
        public PluginArray Plugins {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Standalone {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns the complete User-Agent header.
        /// </summary>
        [ScriptField]
        public string UserAgent {
            get {
                return null;
            }
        }
    }
}
