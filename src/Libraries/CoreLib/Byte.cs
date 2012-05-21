// Byte.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The byte data type which is mapped to the Number type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Number")]
    public struct Byte {

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
        public static implicit operator Number(byte i) {
            return null;
        }
    }
}
