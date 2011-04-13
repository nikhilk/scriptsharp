// jQueryNameValuePair.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents a name and value.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryNameValuePair {

        private jQueryNameValuePair() {
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [IntrinsicProperty]
        public string Name {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        [IntrinsicProperty]
        public object Value {
            get {
                return null;
            }
        }
    }
}
