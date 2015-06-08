// GeoCoordinates.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class GeoCoordinates {

        private GeoCoordinates() {
        }

        [ScriptField]
        public double Accuracy {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double Altitude {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double AltitudeAccuracy {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double Heading {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double Latitude {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double Longitude {
            get {
                return 0.0;
            }
        }

        [ScriptField]
        public double Speed {
            get {
                return 0.0;
            }
        }
    }
}
