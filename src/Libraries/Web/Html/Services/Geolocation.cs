// Geolocation.cs
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
    public sealed class Geolocation {

        private Geolocation() {
        }

        [IntrinsicProperty]
        [ScriptName("coords")]
        public GeoCoordinates Coordinates {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int Timestamp {
            get {
                return 0;
            }
        }
    }
}
