// GeolocationError.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
