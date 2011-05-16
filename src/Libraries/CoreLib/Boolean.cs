// Boolean.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Boolean type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public struct Boolean {

        /// <summary>
        /// Enables you to parse a string representation of a boolean value.
        /// </summary>
        /// <param name="s">The string to be parsed.</param>
        /// <returns>The resulting boolean value.</returns>
        public static bool Parse(string s) {
            return false;
        }
    }
}
