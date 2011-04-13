// FileCollection.cs
// Script#/Libraries/Windows
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
