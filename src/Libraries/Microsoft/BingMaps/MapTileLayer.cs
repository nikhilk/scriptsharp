// MapTileLayer.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Other members

    [Imported]
    [ScriptName("TileLayer")]
    public class MapTileLayer : MapEntity {

        public MapTileLayer(MapTileLayerOptions options) {
        }

        public double GetOpacity() {
            return 0;
        }

        public MapTileSource GetTileSource() {
            return null;
        }

        public int GetZIndex() {
            return 0;
        }

        public void SetOptions(MapTileLayerOptions options) {
        }
    }
}
