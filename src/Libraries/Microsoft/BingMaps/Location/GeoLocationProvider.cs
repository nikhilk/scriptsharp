// GeoLocationProvider.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [Imported]
    public sealed class GeoLocationProvider {

        public GeoLocationProvider(Map map) {
        }

        public void AddAccuracyCircle(MapLocation location, double radius, int segments, GeoLocationCircleOptions options) {
        }

        public void CancelRequest() {
        }

        public void GetCurrentPosition(GeoLocationOptions options) {
        }

        public void RemoveAccuracyCircle() {
        }
    }
}
