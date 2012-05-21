// GeoLocationError.cs
// Script#/Libraries/Microsoft/BingMaps
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maps.Location {

    [Imported]
    [ScriptName("Object")]
    public sealed class GeoLocationError {

        private GeoLocationError() {
        }

        [IntrinsicProperty]
        public int ErrorCode {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("internalError.code")]
        public int InternalCode {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [ScriptName("internalError.message")]
        public string Message {
            get {
                return null;
            }
        }
    }
}
