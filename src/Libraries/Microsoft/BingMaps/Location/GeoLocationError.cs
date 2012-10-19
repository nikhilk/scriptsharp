// GeoLocationError.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [ScriptImport]
    [ScriptName("Object")]
    public sealed class GeoLocationError {

        private GeoLocationError() {
        }

        [ScriptField]
        public int ErrorCode {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("internalError.code")]
        public int InternalCode {
            get {
                return 0;
            }
        }

        [ScriptField]
        [ScriptName("internalError.message")]
        public string Message {
            get {
                return null;
            }
        }
    }
}
