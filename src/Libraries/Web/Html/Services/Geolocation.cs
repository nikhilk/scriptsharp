// Geolocation.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Geolocation {

        private Geolocation() {
        }

        [ScriptField]
        [ScriptName("coords")]
        public GeoCoordinates Coordinates {
            get {
                return null;
            }
        }

        [ScriptField]
        public int Timestamp {
            get {
                return 0;
            }
        }
    }
}
