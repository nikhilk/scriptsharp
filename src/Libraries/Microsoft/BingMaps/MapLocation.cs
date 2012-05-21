// MapLocation.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("Location")]
    public sealed class MapLocation {

        public MapLocation(double latitude, double longitude) {
        }

        public MapLocation(double latitude, double longitude, double altitude, MapAltitudeMode altitudeMode) {
        }

        [IntrinsicProperty]
        public double Altitude {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public MapAltitudeMode AltitudeMode {
            get {
                return MapAltitudeMode.Ground;
            }
        }

        [IntrinsicProperty]
        public double Latitude {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Longitude {
            get {
                return 0;
            }
        }

        public static bool AreEqual(MapLocation location1, MapLocation location2) {
            return false;
        }

        public MapLocation Clone() {
            return null;
        }

        public static double NormalizeLongitude(double longitude) {
            return 0;
        }
    }
}
