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

        [IntrinsicProperty]
        public MapBounds Bounds {
            get {
                return null;
            }
        }

        [ScriptName("categoryName")]
        [IntrinsicProperty]
        public string Category {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public VenueFloor Floor {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string ID {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public MapLocation[] Locations {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
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
