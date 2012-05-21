// MapEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    public abstract class MapShape : MapEntity {

        public MapLocation[] GetLocations() {
            return null;
        }

        public MapColor GetStrokeColor() {
            return null;
        }

        public string GetStrokeDashArray() {
            return null;
        }

        public int GetStrokeThickness() {
            return 0;
        }

        public void SetLocations(MapLocation[] locations) {
        }
    }
}
