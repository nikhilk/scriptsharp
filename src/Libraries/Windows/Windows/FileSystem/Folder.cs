// Folder.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Provides access to properties and operations on a folder.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class Folder {

        private Folder() {
        }

        /// <summary>
        /// Gets or sets the attributes associated with the folder.
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
        /// Gets the date and time the folder was created.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public Date DateCreated {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the date and time the folder was last accessed.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public Date DateLastAccessed {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the date and time the folder was last modified.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public Date DateLastModified {
            get {
                return null;
            }
        }

        /// <summary>
        /// The drive letter associated with this folder.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Drive {
            get {
                return null;
            }
        }

        /// <summary>
        /// Returns a collection of files within this folder.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public FileCollection Files {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the name associated with this folder.
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
        /// Gets the folder containing this folder.
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
        /// Returns a collection of folders within this folder.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public FolderCollection SubFolders {
            get {
                return null;
            }
        }

        /// <summary>
        /// Copies the folder to the specified destination.
        /// </summary>
        /// <param name="destination">The destination path.</param>
        [PreserveCase]
        public void Copy(string destination) {
        }

        /// <summary>
        /// Copies the folder to the specified destination.
        /// </summary>
        /// <param name="destination">The destination path.</param>
        /// <param name="overwrite">Whether any existing folders and files should be overwritten or not.</param>
        [PreserveCase]
        public void Copy(string destination, bool overwrite) {
        }

        /// <summary>
        /// Creates the specified ASCII text file.
        /// </summary>
        /// <param name="name">The name of the file to create.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream CreateTextFile(string name) {
            return null;
        }

        /// <summary>
        /// Creates the specified ASCII text file.
        /// </summary>
        /// <param name="name">The name of the file to create.</param>
        /// <param name="overwrite">Whether an existing file should be overwritten.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream CreateTextFile(string name, bool overwrite) {
            return null;
        }

        /// <summary>
        /// Creates the specified ASCII or Unicode text file.
        /// </summary>
        /// <param name="name">The name of the file to create.</param>
        /// <param name="overwrite">Whether an existing file should be overwritten.</param>
        /// <param name="unicode">Whether the file will be unicode or ASCII.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream CreateTextFile(string name, bool overwrite, bool unicode) {
            return null;
        }

        /// <summary>
        /// Deletes the folder.
        /// </summary>
        [PreserveCase]
        public void Delete() {
        }

        /// <summary>
        /// Deletes the folder.
        /// </summary>
        /// <param name="force">True if the folder should be deleted even if it is read-only.</param>
        [PreserveCase]
        public void Delete(bool force) {
        }

        /// <summary>
        /// Moves the folder to the specified destination.
        /// </summary>
        /// <param name="destination">The new location for the folder.</param>
        [PreserveCase]
        public void Move(string destination) {
        }
    }
}
