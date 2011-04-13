// File.cs
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
    /// Provides access to properties and operations on a file.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class File {

        private File() {
        }

        /// <summary>
        /// Gets or sets the attributes associated with the file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public FileAttributes Attributes {
            get {
                return FileAttributes.Normal;
            }
            set {
            }
        }

        /// <summary>
        /// Gets the date and time the file was created.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public DateTime DateCreated {
            get {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the date and time the file was last accessed.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public DateTime DateLastAccessed {
            get {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the date and time the file was last modified.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public DateTime DateLastModified {
            get {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// The drive letter associated with this file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Drive {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the name associated with this file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Name {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets the folder containing this file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public Folder ParentFolder {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the path of this file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Path {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the size of the file in bytes.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int Size {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the type of the file based on its extension.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Type {
            get {
                return null;
            }
        }

        /// <summary>
        /// Copies the file to the specified destination.
        /// </summary>
        /// <param name="destination">The destination path.</param>
        [PreserveCase]
        public void Copy(string destination) {
        }

        /// <summary>
        /// Copies the file to the specified destination.
        /// </summary>
        /// <param name="destination">The destination path.</param>
        /// <param name="overwrite">Whether any existing files should be overwritten or not.</param>
        [PreserveCase]
        public void Copy(string destination, bool overwrite) {
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        [PreserveCase]
        public void Delete() {
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="force">True if the file should be deleted even if it is read-only.</param>
        [PreserveCase]
        public void Delete(bool force) {
        }

        /// <summary>
        /// Moves the file to the specified destination.
        /// </summary>
        /// <param name="destination">The new location for the file.</param>
        [PreserveCase]
        public void Move(string destination) {
        }

        /// <summary>
        /// Opens the file for reading and writing as ASCII text.
        /// </summary>
        /// <returns>A TextStream to read and write to the file.</returns>
        [PreserveCase]
        public TextStream OpenAsTextStream() {
            return null;
        }

        /// <summary>
        /// Opens the file for reading or writing as specified by the mode as ASCII text.
        /// </summary>
        /// <param name="mode">The mode to determine whether to open the file for reading or writing.</param>
        /// <returns>A TextStream to read or write to the file.</returns>
        [PreserveCase]
        public TextStream OpenAsTextStream(FileMode mode) {
            return null;
        }

        /// <summary>
        /// Opens the file for reading or writing as specified by the mode as ASCII or Unicode text.
        /// </summary>
        /// <param name="mode">The mode to determine whether to open the file for reading or writing.</param>
        /// <param name="format">The format of the file.</param>
        /// <returns>A TextStream to read or write to the file.</returns>
        [PreserveCase]
        public TextStream OpenAsTextStream(FileMode mode, FileFormat format) {
            return null;
        }
    }
}
