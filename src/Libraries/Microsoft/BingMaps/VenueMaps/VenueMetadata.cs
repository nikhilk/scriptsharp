// VenueMapOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueMetadata {

        private VenueMetadata() {
        }

        [PreserveCase]
        [IntrinsicProperty]
        public string DefaultFloor {
            get {
                return null;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
        public string FloorHeader {
            get {
                return null;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
        public VenueFloor[] Floors {
            get {
                return null;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
        public VenueFootprint Footprint {
            get {
                return null;
            }
        }

        [ScriptName("MapId")]
        [IntrinsicProperty]
        public string ID {
            get {
                return null;
            }
        }

        [ScriptName("CenterLat")]
        [IntrinsicProperty]
        public double Latitude {
            get {
                return 0;
            }
        }

        [ScriptName("CenterLong")]
        [IntrinsicProperty]
        public double Longitude {
            get {
                return 0;
            }
        }

        [PreserveCase]
        [IntrinsicProperty]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptName("MapType")]
        [IntrinsicProperty]
        public VenueType Type {
            get {
                return VenueType.Mall;
            }
        }
    }
}
