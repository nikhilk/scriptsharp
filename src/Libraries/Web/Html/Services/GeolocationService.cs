// GeolocationService.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    public delegate void GeolocationSuccessCallback(Geolocation location);

    public delegate void GeolocationErrorCallback(GeolocationError error);

    [IgnoreNamespace]
    [Imported]
    public sealed class GeolocationService {

        private GeolocationService() {
        }

        public void ClearWatch(object watchCookie) {
        }

        public void GetCurrentPosition(GeolocationSuccessCallback successCallback) {
        }

        public void GetCurrentPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback) {
        }

        public void GetCurrentPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback, GeolocationOptions options) {
        }

        public object WatchPosition(GeolocationSuccessCallback successCallback) {
            return null;
        }

        public object WatchPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback) {
            return null;
        }

        public object WatchPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback, GeolocationOptions options) {
            return null;
        }
    }
}
