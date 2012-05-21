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

        [IntrinsicProperty]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public MapLocation[] Locations {
            get {
                return null;
            }
        }
    }
}
