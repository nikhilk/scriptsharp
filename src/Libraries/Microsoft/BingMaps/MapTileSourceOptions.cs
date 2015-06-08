// MapTileSourceOptions.cs
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
    public sealed class MapTileSourceOptions {

        public double Width;
        public double Height;
        [ScriptName("uriConstructor")]
        public string UriFormat;
        [ScriptName("uriConstructor")]
        public MapTileUriGenerator UriGenerator;
    }
}
