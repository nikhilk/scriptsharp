// VenueEntityPolygon.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueEntityPolygon {

        private VenueEntityPolygon() {
        }

        [ScriptProperty]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public MapLocation[] Locations {
            get {
                return null;
            }
        }
    }
}
