// FileAttributes.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    // [NumericValues]
    /// <summary>
    /// Attributes associated with a file or folder.
    /// </summary>
    [Flags]
    [Imported]
    public enum FileAttributes {

        /// <summary>
        /// No attributes are set.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Read-only file or folder.
        /// </summary>
        ReadOnly = 1,

        /// <summary>
        /// Hidden file or folder.
        /// </summary>
        Hidden = 2,

        /// <summary>
        /// System file or folder.
        /// </summary>
        System = 4,

        /// <summary>
        /// Volume label for disk (read-only)
        /// </summary>
        Volume = 8,

        /// <summary>
        /// Folder (read-only)
        /// </summary>
        Directory = 16,

        /// <summary>
        /// File changed since last backup
        /// </summary>
        Archive = 32,

        /// <summary>
        /// Link or shortcut (read-only)
        /// </summary>
        Alias = 1024,

        /// <summary>
        /// Compressed (read-only)
        /// </summary>
        Compressed = 2048
    }
}
