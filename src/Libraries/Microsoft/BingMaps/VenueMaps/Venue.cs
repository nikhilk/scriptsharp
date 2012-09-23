// Venue.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class Venue {

        private Venue() {
        }

        [ScriptProperty]
        public double Distance {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public VenueMetadata Metadata {
            get {
                return null;
            }
        }
    }
}
