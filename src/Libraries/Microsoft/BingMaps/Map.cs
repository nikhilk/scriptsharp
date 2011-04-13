// Map.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps {

    [Imported]
    public sealed class Map {

        public Map(Element element) {
        }

        public Map(Element element, MapOptions options) {
        }

        [IntrinsicProperty]
        public MapEntityCollection Entities {
            get {
                return null;
            }
        }

        public void Blur() {
        }

        public void Dispose() {
        }

        public void Focus() {
        }

        public MapBounds GetBounds() {
            return null;
        }

        public MapLocation GetCenter() {
            return null;
        }

        public string[] GetCopyrights() {
            return null;
        }

        public int GetHeading() {
            return 0;
        }

        public int GetHeight() {
            return 0;
        }

        public string GetImageryId() {
            return null;
        }

        [ScriptName("getMapTypeId")]
        public MapType GetMapType() {
            return MapType.Auto;
        }

        public double GetMetersPerPixel() {
            return 0;
        }

        public MapOptions GetOptions() {
            return null;
        }

        public int GetPageX() {
            return 0;
        }

        public int GetPageY() {
            return 0;
        }

        public Element GetRootElement() {
            return null;
        }

        public MapBounds GetTargetBounds() {
            return null;
        }

        public MapLocation GetTargetCenter() {
            return null;
        }

        public int GetTargetHeading() {
            return 0;
        }

        public double GetTargetMetersPerPixel() {
            return 0;
        }

        public int GetTargetZoom() {
            return 0;
        }

        public int GetViewportX() {
            return 0;
        }

        public int GetViewportY() {
            return 0;
        }

        public int GetWidth() {
            return 0;
        }

        public int GetZoom() {
            return 0;
        }

        public MapZoomRange GetZoomRange() {
            return null;
        }

        public bool IsMercator() {
            return false;
        }

        public bool IsRotationEnabled() {
            return false;
        }

        public void SetOptions(MapOptions options) {
        }

        public void SetView(MapViewOptions options) {
        }

        public MapPoint TryLocationToPixel(MapLocation location) {
            return null;
        }

        public MapPoint TryLocationToPixel(MapLocation location, MapPointReference pointReference) {
            return null;
        }

        [ScriptName("tryLocationToPixel")]
        public MapPoint[] TryLocationsToPixels(MapLocation[] locations) {
            return null;
        }

        [ScriptName("tryLocationToPixel")]
        public MapPoint[] TryLocationsToPixels(MapLocation[] locations, MapPointReference pointReference) {
            return null;
        }

        public MapLocation TryPixelToLocation(MapPoint p) {
            return null;
        }

        public MapLocation TryPixelToLocation(MapPoint p, MapPointReference pointReference) {
            return null;
        }

        [ScriptName("tryPixelToLocation")]
        public MapLocation[] TryPixelsToLocations(MapPoint[] points) {
            return null;
        }

        [ScriptName("tryPixelToLocation")]
        public MapLocation[] TryPixelsToLocations(MapPoint[] points, MapPointReference pointReference) {
            return null;
        }
    }
}
