// MapEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
