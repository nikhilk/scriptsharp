// GeolocationError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [IgnoreNamespace]
    [Imported]
    public sealed class GeolocationError {

        private GeolocationError() {
        }

        [IntrinsicProperty]
        public GeolocationErrorCode Code {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string Message {
            get {
                return null;
            }
        }
    }
}
