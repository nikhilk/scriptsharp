// MapType.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("MapTypeId")]
    public enum MapType {

        Auto,

        Road,

        Aerial,

        Birdseye,

        [ScriptName("mercator")]
        Custom
    }
}
