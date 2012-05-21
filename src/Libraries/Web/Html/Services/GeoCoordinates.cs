// GeoCoordinates.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [IgnoreNamespace]
    [Imported]
    public sealed class GeoCoordinates {

        private GeoCoordinates() {
        }

        [IntrinsicProperty]
        public double Accuracy {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double Altitude {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double AltitudeAccuracy {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double Heading {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double Latitude {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double Longitude {
            get {
                return 0.0;
            }
        }

        [IntrinsicProperty]
        public double Speed {
            get {
                return 0.0;
            }
        }
    }
}
