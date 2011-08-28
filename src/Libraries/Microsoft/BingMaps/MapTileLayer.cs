// MapTileLayer.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
