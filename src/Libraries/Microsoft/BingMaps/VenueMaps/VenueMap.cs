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

        [ScriptProperty]
        public string Address {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public MapViewOptions BestMapView {
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
        public string DefaultFloor {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string FloorHeader {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public VenueFloor[] Floors {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public VenueFootprint Footprint {
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
        public string Name {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string PhoneNumber {
            get {
                return null;
            }
        }

        [ScriptProperty]
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
