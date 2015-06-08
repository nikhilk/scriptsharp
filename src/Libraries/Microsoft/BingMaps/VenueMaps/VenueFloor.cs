// VenueFloor.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueFloor {

        private VenueFloor() {
        }

        [ScriptName("primitives")]
        [ScriptField]
        public VenueEntity[] Entities {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        public int[] ZoomRange {
            get {
                return null;
            }
        }
    }
}
