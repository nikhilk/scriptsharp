// MapPolygonOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    // TODO: Make properties

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class MapPolygonOptions {

        public int StrokeThickness;
        public MapColor StrokeColor;
        public string StrokeDashArray;
        public MapColor FillColor;
        public bool Visible;
    }
}
