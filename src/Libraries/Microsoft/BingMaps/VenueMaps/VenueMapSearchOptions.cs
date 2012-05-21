// VenueMapSearchOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    // TODO: Make properties

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueMapSearchOptions {

        public VenueMapSearchCallback Callback;

        public MapLocation Location;

        public Map Map;

        public double Radius;
    }
}
