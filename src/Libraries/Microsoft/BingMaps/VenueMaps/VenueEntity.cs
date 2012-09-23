// VenueEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class VenueEntity {

        private VenueEntity() {
        }

        [ScriptProperty]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [ScriptName("categoryName")]
        [ScriptProperty]
        public string Category {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public VenueFloor Floor {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string ID {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public MapLocation[] Locations {
            get {
                return null;
            }
        }

        [ScriptProperty]
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
