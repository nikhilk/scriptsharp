// GeolocationOptions.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class GeolocationOptions {

        public GeolocationOptions(params object[] nameValuePairs) {
        }

        [IntrinsicProperty]
        public bool EnableHighAccuracy {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int MaximumAge {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Timeout {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
