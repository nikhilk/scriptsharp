// MapViewOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
        public MapPoint CenterOffset;
        public int Heading;
        public int Zoom;
        public int Padding;
        public MapBounds Bounds;
        public bool Animate;
        public MapLabelOverlay LabelOverlay;
    }
}
