// VenueEntityPolygon.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueEntityPolygon {

        private VenueEntityPolygon() {
        }

        [ScriptField]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [ScriptField]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [ScriptField]
        public MapLocation[] Locations {
            get {
                return null;
            }
        }
    }
}
