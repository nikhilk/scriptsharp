// GeolocationError.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Services {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class GeolocationError {

        private GeolocationError() {
        }

        [ScriptField]
        public GeolocationErrorCode Code {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string Message {
            get {
                return null;
            }
        }
    }
}
