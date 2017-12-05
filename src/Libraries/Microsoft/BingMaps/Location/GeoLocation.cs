// GeoLocation.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html.Services;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [ScriptImport]
    [ScriptName("Object")]
    public sealed class GeoLocation {

        private GeoLocation() {
        }

        [ScriptField]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("position.coords")]
        public GeoCoordinates Coordinates {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("position.timestamp")]
        public string Timestamp {
            get {
                return null;
            }
        }
    }
}
