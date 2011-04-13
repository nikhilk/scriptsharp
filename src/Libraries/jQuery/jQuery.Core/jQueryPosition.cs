// jQueryPosition.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace jQueryApi {

    /// <summary>
    /// Provides information about the position of an element.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryPosition {

        private jQueryPosition() {
        }

        /// <summary>
        /// Gets the left coordinate.
        /// </summary>
        [IntrinsicProperty]
        public int Left {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the top coordinate.
        /// </summary>
        [IntrinsicProperty]
        public int Top {
            get {
                return 0;
            }
        }

        public static implicit operator Dictionary(jQueryPosition position) {
            return null;
        }
    }
}
