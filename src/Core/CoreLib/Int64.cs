// Int64.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The long data type which is mapped to the Number type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Number")]
    public struct Int64 {

        [ScriptName("MAX_VALUE")]
        public const long MaxValue = 0;

        [ScriptName("MIN_VALUE")]
        public const long MinValue = 0;

        /// <summary>
        /// Converts the value to its string representation.
        /// </summary>
        /// <param name="radix">The radix used in the conversion (eg. 10 for decimal, 16 for hexadecimal)</param>
        /// <returns>The string representation of the value.</returns>
        public string ToString(int radix) {
            return null;
        }

        /// <internalonly />
        public static implicit operator Number(long i) {
            return null;
        }
    }
}
