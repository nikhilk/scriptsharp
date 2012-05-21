// VenueMap.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [Imported]
    public sealed class VenueMap {

        private VenueMap() {
        }

        [IntrinsicProperty]
        public string Address {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public MapViewOptions BestMapView {
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
        public string DefaultFloor {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string FloorHeader {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public VenueFloor[] Floors {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public VenueFootprint Footprint {
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
        public string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string PhoneNumber {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public VenueType Type {
            get {
                return VenueType.Mall;
            }
        }

        public void Dispose() {
        }

        public string GetActiveFloor() {
            return null;
        }

        public void Hide() {
        }

        public void SetActiveFloor(string venueMapID, string floor) {
        }

        public void Show() {
        }
    }
}
