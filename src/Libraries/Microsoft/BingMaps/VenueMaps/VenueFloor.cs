// VenueFloor.cs
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
    public sealed class VenueFloor {

        private VenueFloor() {
        }

        [ScriptName("primitives")]
        [IntrinsicProperty]
        public VenueEntity[] Entities {
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

        [IntrinsicProperty]
        public int[] ZoomRange {
            get {
                return null;
            }
        }
    }
}
