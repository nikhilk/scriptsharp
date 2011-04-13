// GeoCoordinates.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
