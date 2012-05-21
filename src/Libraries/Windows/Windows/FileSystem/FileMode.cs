// FileMode.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    // [NumericValues]
    /// <summary>
    /// Represents the mode in which a text file is opened.
    /// </summary>
    [Imported]
    public enum FileMode {

        /// <summary>
        /// Open a file for reading only.
        /// </summary>
        ForReading = 1,

        /// <summary>
        /// Open a file for writing.
        /// </summary>
        ForWriting = 2,

        /// <summary>
        /// Open a file for writing at the end.
        /// </summary>
        ForAppending = 8
    }
}
