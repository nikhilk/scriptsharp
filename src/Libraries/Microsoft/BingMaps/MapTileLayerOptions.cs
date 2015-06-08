// MapTileLayerOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class MapTileLayerOptions {

        public double Opacity;
        public int ZIndex;
        public MapTileSource Mercator;
        public bool Visible;
        public MapAnimationVisibility AnimationDisplay;
    }
}
