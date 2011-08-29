// MapModule.cs
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
