// MapModule.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [NamedValues]
    [IgnoreNamespace]
    public enum MapModule {

        [ScriptName("Microsoft.Maps.Directions")]
        Directions,

        [ScriptName("Microsoft.Maps.Traffic")]
        Traffic,

        [ScriptName("Microsoft.Maps.VenueMaps")]
        VenueMaps
    }
}
