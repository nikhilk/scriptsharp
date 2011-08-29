// GeoLocation.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Html.Services;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [Imported]
    [ScriptName("Object")]
    public sealed class GeoLocation {

        private GeoLocation() {
        }

        [IntrinsicProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("position.coords")]
        public GeoCoordinates Coordinates {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [ScriptName("position.timestamp")]
        public string Timestamp {
            get {
                return null;
            }
        }
    }
}
