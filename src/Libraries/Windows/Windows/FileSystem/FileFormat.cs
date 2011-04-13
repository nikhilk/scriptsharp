// FileFormat.cs
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
