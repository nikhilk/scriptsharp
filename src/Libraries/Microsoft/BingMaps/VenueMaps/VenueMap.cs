// VenueMap.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.VenueMaps {

    [ScriptImport]
    public sealed class VenueMap {

        private VenueMap() {
        }

        [ScriptField]
        public string Address {
            get {
                return null;
            }
        }

        [ScriptField]
        public MapViewOptions BestMapView {
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
        public string DefaultFloor {
            get {
                return null;
            }
        }

        [ScriptField]
        public string FloorHeader {
            get {
                return null;
            }
        }

        [ScriptField]
        public VenueFloor[] Floors {
            get {
                return null;
            }
        }

        [ScriptField]
        public VenueFootprint Footprint {
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
        public string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        public string PhoneNumber {
            get {
                return null;
            }
        }

        [ScriptField]
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
