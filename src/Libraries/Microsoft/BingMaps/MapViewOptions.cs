// MapViewOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [Imported]
    [ScriptName("Object")]
    [IgnoreNamespace]
    public sealed class MapViewOptions {

        [ScriptName("mapTypeId")]
        public MapType MapType;
        public MapLocation Center;
        public int Zoom;
        public int Padding;
        public MapBounds Bounds;
        public bool Animate;
        public MapLabelOverlay LabelOverlay;
    }
}
