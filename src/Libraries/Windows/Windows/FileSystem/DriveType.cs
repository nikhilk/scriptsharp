// DriveType.cs
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
    public enum DriveType {

        /// <summary>
        /// Unknown drive type
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Removable drive
        /// </summary>
        Removable = 1,

        /// <summary>
        /// Fixed drive
        /// </summary>
        Fixed = 2,

        /// <summary>
        /// Network share
        /// </summary>
        Network = 3,

        /// <summary>
        /// CD-ROM drive
        /// </summary>
        CDROM = 4,

        /// <summary>
        /// RAM disk
        /// </summary>
        RAMDisk = 5
    }
}
