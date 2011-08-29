// GeoLocationOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    // TODO: Make properties

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class GeoLocationOptions {

        public bool EnableHighAccuracy;

        public Action<GeoLocationError> ErrorCallback;

        public int MaximumAge;

        public bool ShowAccuracyCircle;

        public Action<GeoLocation> SuccessCallback;

        public int Timeout;

        public bool UpdateMapView;
    }
}
