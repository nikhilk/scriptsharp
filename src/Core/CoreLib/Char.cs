// Char.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The char data type which is mapped to the String type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("String")]
    public struct Char {

        /// <internalonly />
        public static explicit operator String(char ch) {
            return null;
        }
    }
}
