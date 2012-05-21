// GeoLocationProvider.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [Imported]
    [ScriptNamespace("Microsoft.Maps")]
    public sealed class GeoLocationProvider {

        public GeoLocationProvider(Map map) {
        }

        public void AddAccuracyCircle(MapLocation location, double radius, int segments, GeoLocationCircleOptions options) {
        }

        public void CancelRequest() {
        }

        public void GetCurrentPosition() {
        }

        public void GetCurrentPosition(GeoLocationOptions options) {
        }

        public void RemoveAccuracyCircle() {
        }
    }
}
