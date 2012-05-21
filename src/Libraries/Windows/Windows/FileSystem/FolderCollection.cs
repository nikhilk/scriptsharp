// FolderCollection.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Represents a set of folder.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class FolderCollection {

        private FolderCollection() {
        }

        /// <summary>
        /// Gets the number of folder in the collection.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int Count {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the specified folder.
        /// </summary>
        [IntrinsicProperty]
        public Folder this[int index] {
            get {
                return null;
            }
        }
    }
}
