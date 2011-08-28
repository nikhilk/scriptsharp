// MapTileSource.cs
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
    [ScriptName("TileSource")]
    public class MapTileSource {

        public MapTileSource(MapTileSourceOptions options) {
        }

        public int GetHeight() {
            return 0;
        }

        public string GetUriConstructor() {
            return null;
        }

        public int GetWidth() {
            return 0;
        }
    }
}
