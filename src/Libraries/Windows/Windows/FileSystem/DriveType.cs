// DriveType.cs
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
