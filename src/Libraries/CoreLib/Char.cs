// Char.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The char data type which is mapped to the String type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("String")]
    public struct Char {

        /// <internalonly />
        public static explicit operator String(char ch) {
            return null;
        }
    }
}
