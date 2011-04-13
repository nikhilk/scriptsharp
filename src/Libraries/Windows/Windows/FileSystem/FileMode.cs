// FileMode.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
