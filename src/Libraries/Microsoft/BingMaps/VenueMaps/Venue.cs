// Venue.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class Venue {

        private Venue() {
        }

        [ScriptField]
        public double Distance {
            get {
                return 0;
            }
        }

        [ScriptField]
        public VenueMetadata Metadata {
            get {
                return null;
            }
        }
    }
}
