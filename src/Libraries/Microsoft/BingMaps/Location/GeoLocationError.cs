// GeoLocationError.cs
// Script#/Libraries/Microsoft/BingMaps
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
