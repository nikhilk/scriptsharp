// VenueEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueEntity {

        private VenueEntity() {
        }

        [ScriptField]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [ScriptName("categoryName")]
        [ScriptField]
        public string Category {
            get {
                return null;
            }
        }

        [ScriptField]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [ScriptField]
        public VenueFloor Floor {
            get {
                return null;
            }
        }

        [ScriptField]
        public string ID {
            get {
                return null;
            }
        }

        [ScriptField]
        public MapLocation[] Locations {
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

        public void Highlight() {
        }

        public void Unhighlight() {
        }
    }
}
