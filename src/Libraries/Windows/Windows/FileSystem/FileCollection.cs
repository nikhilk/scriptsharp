// FileCollection.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Represents a set of files.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class FileCollection {

        private FileCollection() {
        }

        /// <summary>
        /// Gets the number of files in the collection.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int Count {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the specified file.
        /// </summary>
        [IntrinsicProperty]
        public File this[int index] {
            get {
                return null;
            }
        }
    }
}
