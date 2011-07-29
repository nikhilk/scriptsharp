// Navigator.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
        /// (Gecko, Chrome, Opera, WebKit) Returns a string representing the language of the browser.
        /// </summary>
        [IntrinsicProperty]
        public string Language {
            get {
                return null;
            }
        }

        /// <summary>
        /// (IE, Opera) Retrieves the operating system's natural language setting.
        /// </summary>
        [IntrinsicProperty]
        public string UserLanguage {
            get {
                return null;
            }
        }

        /// <summary>
        /// (IE) Retrieves the default language used by the operating system.
        /// </summary>
        [IntrinsicProperty]
        public string SystemLanguage {
            get {
                return null;
            }
        }

        /// <summary>
        /// (IE, Opera) Retrieves the current language.
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
