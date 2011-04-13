// GeolocationService.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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

        public object WatchCurrentPosition(GeolocationSuccessCallback successCallback) {
            return null;
        }

        public object WatchCurrentPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback) {
            return null;
        }

        public object WatchCurrentPosition(GeolocationSuccessCallback successCallback, GeolocationErrorCallback errorCallback, GeolocationOptions options) {
            return null;
        }
    }
}
