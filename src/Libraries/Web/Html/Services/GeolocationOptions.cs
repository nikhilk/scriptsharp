// GeolocationOptions.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [IgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class GeolocationOptions {

        public GeolocationOptions(params object[] nameValuePairs) {
        }

        [ScriptProperty]
        public bool EnableHighAccuracy {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public int MaximumAge {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Timeout {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
