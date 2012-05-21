// FileFormat.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    // [NumericValues]
    /// <summary>
    /// Represents the format of the file to be opened.
    /// </summary>
    [Imported]
    public enum FileFormat {

        /// <summary>
        /// Opens the file as ASCII.
        /// </summary>
        ASCII = 0,

        /// <summary>
        /// Opens the file as Unicode.
        /// </summary>
        Unicode = -1,

        /// <summary>
        /// Opens the file using the system default.
        /// </summary>
        Default = -2
    }
}
