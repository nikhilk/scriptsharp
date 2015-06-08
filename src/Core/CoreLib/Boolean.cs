// Boolean.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Boolean type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public struct Boolean {

        /// <summary>
        /// Enables you to parse a string representation of a boolean value.
        /// </summary>
        /// <param name="s">The string to be parsed.</param>
        /// <returns>The resulting boolean value.</returns>
        [ScriptAlias("ss.boolean")]
        public static bool Parse(string s) {
            return false;
        }
    }
}
