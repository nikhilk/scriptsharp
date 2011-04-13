// MapBounds.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("LocationRect")]
    public sealed class MapBounds {

        public MapBounds(MapLocation center, double width, double height) {
        }

        [IntrinsicProperty]
        public MapLocation Center {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public double Height {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Width {
            get {
                return 0;
            }
        }

        public bool Contains(MapLocation location) {
            return false;
        }

        public static MapBounds FromCorners(MapLocation northWest, MapLocation southEast) {
            return null;
        }

        public static MapBounds FromEdges(double north, double west, double south, double east) {
            return null;
        }

        public static MapBounds FromLocations(params MapLocation[] locations) {
            return null;
        }

        public static MapBounds FromString(string location) {
            return null;
        }

        public double GetEast() {
            return 0;
        }

        public double GetNorth() {
            return 0;
        }

        public MapLocation GetNorthwest() {
            return null;
        }

        public double GetSouth() {
            return 0;
        }

        public MapLocation GetSoutheast() {
            return null;
        }

        public double GetWest() {
            return 0;
        }

        public bool Intersects(MapBounds locationRect) {
            return false;
        }
    }
}
