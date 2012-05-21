// MapPoint.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    [ScriptName("Point")]
    public sealed class MapPoint {

        public MapPoint(double x, double y) {
        }

        [IntrinsicProperty]
        public double X {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public double Y {
            get {
                return 0;
            }
        }

        public static MapPoint Add(MapPoint p1, MapPoint p2) {
            return null;
        }

        public static bool AreEqual(MapPoint p1, MapPoint p2) {
            return false;
        }

        public MapPoint Clone() {
            return null;
        }

        public static double Distance(MapPoint p1, MapPoint p2) {
            return 0;
        }

        public static MapPoint Multiply(MapPoint p1, MapPoint p2) {
            return null;
        }

        public static MapPoint Subtract(MapPoint p1, MapPoint p2) {
            return null;
        }
    }
}
