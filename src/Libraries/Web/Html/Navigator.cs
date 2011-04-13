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

        [IntrinsicProperty]
        public string AppVersion {
            get {
                return null;
            }
        }

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

        [IntrinsicProperty]
        public string UserAgent {
            get {
                return null;
            }
        }
    }
}
