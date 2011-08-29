// VenueEntity.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
