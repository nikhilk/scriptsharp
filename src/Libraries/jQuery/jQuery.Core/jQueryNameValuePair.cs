// jQueryNameValuePair.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
