// MapZoomRange.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [ScriptImport]
    [ScriptName("Object")]
    [ScriptIgnoreNamespace]
    public sealed class MapZoomRange {

        [ScriptField]
        public int Min {
            get;
            set;
        }

        [ScriptField]
        public int Max {
            get;
            set;
        }
    }
}
