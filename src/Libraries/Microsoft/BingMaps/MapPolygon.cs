// MapPolygon.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Other members

    [Imported]
    [ScriptName("Polygon")]
    public sealed class MapPolygon : MapShape {

        public MapPolygon(MapLocation[] locations) {
        }

        public MapPolygon(MapLocation[] locations, MapPolygonOptions options) {
        }

        public MapColor GetFillColor() {
            return null;
        }

        public void SetOptions(MapPolygonOptions options) {
        }
    }
}
