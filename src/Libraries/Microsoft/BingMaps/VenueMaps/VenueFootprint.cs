// VenueFootprint.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueFootprint {

        private VenueFootprint() {
        }

        [IntrinsicProperty]
        public VenueEntityPolygon[] Polygons {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int[] ZoomRange {
            get {
                return null;
            }
        }
    }
}
