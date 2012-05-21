// GeoLocationOptions.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
