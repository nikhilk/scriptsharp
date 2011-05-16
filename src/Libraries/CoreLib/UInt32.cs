// UInt32.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The uint data type which is mapped to the Number type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Number")]
    public struct UInt32 {

        public string Format(string format) {
            return null;
        }

        public string LocaleFormat(string format) {
            return null;
        }

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public string ToString(int radix) {
            return null;
        }

        /// <internalonly />
        [CLSCompliant(false)]
        public static implicit operator Number(uint i) {
            return null;
        }
    }
}
