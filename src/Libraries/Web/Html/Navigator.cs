// Navigator.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html.Services;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class Navigator {

        private Navigator() {
        }

        /// <summary>
        /// Returns the name of the browser.
        /// </summary>
        [IntrinsicProperty]
        public string AppName {
            get {
                return null;
            }
        }

        /// <summary>
        /// Returns the version of the browser.
        /// </summary>
        [IntrinsicProperty]
        public string AppVersion {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the current language (applies to IE and Opera).
        /// </summary>
        [IntrinsicProperty]
        public string BrowserLanguage {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool CookieEnabled {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns a string representing the language of the browser (applies to Gecko, Opera, and WebKit).
        /// </summary>
        [IntrinsicProperty]
        public string Language {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the default language used by the operating system (applies to IE).
        /// </summary>
        [IntrinsicProperty]
        public string SystemLanguage {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the operating system's natural language setting (applies to IE and Opera).
        /// </summary>
        [IntrinsicProperty]
        public string UserLanguage {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public GeolocationService Geolocation {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool OnLine {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns the name of the platform.
        /// </summary>
        [IntrinsicProperty]
        public string Platform {
            get {
                return null;
            }
        }

        /// <summary>
        /// Returns a PluginArray object, listing the plugins installed in the application.
        /// </summary>
        [IntrinsicProperty]
        public PluginArray Plugins {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool Standalone {
            get {
                return false;
            }
        }

        /// <summary>
        /// Returns the complete User-Agent header.
        /// </summary>
        [IntrinsicProperty]
        public string UserAgent {
            get {
                return null;
            }
        }
    }
}
