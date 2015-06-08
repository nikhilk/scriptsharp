// VenueMapOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueMetadata {

        private VenueMetadata() {
        }

        [ScriptName(PreserveCase = true)]
        [ScriptField]
        public string DefaultFloor {
            get {
                return null;
            }
        }

        [ScriptName(PreserveCase = true)]
        [ScriptField]
        public string FloorHeader {
            get {
                return null;
            }
        }

        [ScriptName(PreserveCase = true)]
        [ScriptField]
        public VenueFloor[] Floors {
            get {
                return null;
            }
        }

        [ScriptName(PreserveCase = true)]
        [ScriptField]
        public VenueFootprint Footprint {
            get {
                return null;
            }
        }

        [ScriptName("MapId")]
        [ScriptField]
        public string ID {
            get {
                return null;
            }
        }

        [ScriptName("CenterLat")]
        [ScriptField]
        public double Latitude {
            get {
                return 0;
            }
        }

        [ScriptName("CenterLong")]
        [ScriptField]
        public double Longitude {
            get {
                return 0;
            }
        }

        [ScriptName(PreserveCase = true)]
        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptName("MapType")]
        [ScriptField]
        public VenueType Type {
            get {
                return VenueType.Mall;
            }
        }
    }
}
