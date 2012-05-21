// FileSystemObject.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Provides access to the local file system.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class FileSystemObject {

        /// <summary>
        /// Gets the drives on this machine.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public DriveCollection Drives {
            get {
                return null;
            }
        }

        /// <summary>
        /// Appends a name to an existing path to create a new path.
        /// </summary>
        /// <param name="path">A path to which name is appended. It can be absolute or relative.</param>
        /// <param name="name">Name being appended to the existing path.</param>
        /// <returns></returns>
        [PreserveCase]
        public string BuildPath(string path, string name) {
            return null;
        }

        /// <summary>
        /// Copies one or more files from one location to another. Any existing
        /// files are overwritten.
        /// </summary>
        /// <param name="source">File to be copied (can include wildcards).</param>
        /// <param name="destination">Where the file or files from source are to be copied.</param>
        [PreserveCase]
        public void CopyFile(string source, string destination) {
        }

        /// <summary>
        /// Copies one or more files from one location to another.
        /// </summary>
        /// <param name="source">File to be copied (can include wildcards).</param>
        /// <param name="destination">Where the file or files from source are to be copied.</param>
        /// <param name="overwrite">Indicates if existing files are to be overwritten.</param>
        [PreserveCase]
        public void CopyFile(string source, string destination, bool overwrite) {
        }

        /// <summary>
        /// Recursively copies a folder from one location to another. Any existing
        /// folders and files are overwritten.
        /// </summary>
        /// <param name="source">Folder top be copied (can include wildcards).</param>
        /// <param name="destination">Where the specified folders are to be copied.</param>
        [PreserveCase]
        public void CopyFolder(string source, string destination) {
        }

        /// <summary>
        /// Recursively copies a folder from one location to another.
        /// </summary>
        /// <param name="source">Folder top be copied (can include wildcards).</param>
        /// <param name="destination">Where the specified folders are to be copied.</param>
        /// <param name="overwrite">Indicates if existing folders and files are to be overwritten.</param>
        [PreserveCase]
        public void CopyFolder(string source, string destination, bool overwrite) {
        }

        /// <summary>
        /// Creates a new folder.
        /// </summary>
        /// <param name="name">The name of the folder to create.</param>
        /// <returns>A folder object representing the new folder.</returns>
        [PreserveCase]
        public Folder CreateFolder(string name) {
            return null;
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
        /// Deletes the specified file.
        /// </summary>
        /// <param name="name">The file to be deleted.</param>
        [PreserveCase]
        public void DeleteFile(string name) {
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="name">The file to be deleted.</param>
        /// <param name="force">Whether to delete files even if they are marked as read-only.</param>
        [PreserveCase]
        public void DeleteFile(string name, bool force) {
        }

        /// <summary>
        /// Deletes the specified folder and its contents.
        /// </summary>
        /// <param name="name">The folder to be deleted.</param>
        [PreserveCase]
        public void DeleteFolder(string name) {
        }

        /// <summary>
        /// Deletes the specified folder and its contents.
        /// </summary>
        /// <param name="name">The folder to be deleted.</param>
        /// <param name="force">Whether to delete the folder even if it contains files that are marked as read-only.</param>
        [PreserveCase]
        public void DeleteFolder(string name, bool force) {
        }

        /// <summary>
        /// Checks if the specified drive exists.
        /// </summary>
        /// <param name="name">The name of the drive.</param>
        /// <returns>True if the drive exists; false otherwise.</returns>
        [PreserveCase]
        public bool DriveExists(string name) {
            return false;
        }

        /// <summary>
        /// Checks if the specified file exists.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <returns>True if the drive exists; false otherwise.</returns>
        [PreserveCase]
        public bool FileExists(string name) {
            return false;
        }

        /// <summary>
        /// Checks if the specified folder exists.
        /// </summary>
        /// <param name="name">The name of the folder.</param>
        /// <returns>True if the drive exists; false otherwise.</returns>
        [PreserveCase]
        public bool FolderExists(string name) {
            return false;
        }

        /// <summary>
        /// Returns a complete and unambiguous path from a provided path name.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The complete path name.</returns>
        [PreserveCase]
        public string GetAbsolutePathName(string name) {
            return null;
        }

        /// <summary>
        /// Returns the base path of the specified path by stripping off any extension information.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The base path name.</returns>
        [PreserveCase]
        public string GetBaseName(string name) {
            return null;
        }

        /// <summary>
        /// Returns the drive associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated drive name.</returns>
        [PreserveCase]
        public string GetDrive(string name) {
            return null;
        }

        /// <summary>
        /// Returns the extension associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated extension name.</returns>
        [PreserveCase]
        public string GetExtensionName(string name) {
            return null;
        }

        /// <summary>
        /// Returns the file associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated file object.</returns>
        [PreserveCase]
        public object GetFile(string name) {
            // TODO: Return type
            return null;
        }

        /// <summary>
        /// Returns the version associated with the specified file.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <returns>The associated version number.</returns>
        [PreserveCase]
        public string GetFileVersion(string name) {
            return null;
        }

        /// <summary>
        /// Returns the name of the file associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated file name.</returns>
        [PreserveCase]
        public string GetFileName(string name) {
            return null;
        }

        /// <summary>
        /// Returns the folder associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated folder object.</returns>
        [PreserveCase]
        public object GetFolder(string name) {
            // TODO: Return type
            return null;
        }

        /// <summary>
        /// Returns the name of the folder associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated folder name.</returns>
        [PreserveCase]
        public string GetParentFolderName(string name) {
            return null;
        }

        /// <summary>
        /// Returns the name of the folder associated with the specified path.
        /// </summary>
        /// <param name="name">The path name.</param>
        /// <returns>The associated folder name.</returns>
        [PreserveCase]
        public string GetSpecialFolder(string name) {
            return null;
        }

        /// <summary>
        /// Moves one or more files from one location to another.
        /// </summary>
        /// <param name="source">File to be copied (can include wildcards).</param>
        /// <param name="destination">Where the files are to be copied.</param>
        [PreserveCase]
        public void MoveFile(string source, string destination) {
        }

        /// <summary>
        /// Moves one or more folder from one location to another.
        /// </summary>
        /// <param name="source">Folder to be copied (can include wildcards).</param>
        /// <param name="destination">Where the folders are to be copied.</param>
        [PreserveCase]
        public void MoveFolder(string source, string destination) {
        }

        /// <summary>
        /// Opens an existing file for reading/writing ASCII text.
        /// </summary>
        /// <param name="name">The name of the file to open.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream OpenTextFile(string name) {
            return null;
        }

        /// <summary>
        /// Opens an existing file as ASCII text for reading or writing as specified.
        /// </summary>
        /// <param name="name">The name of the file to open.</param>
        /// <param name="mode">Whether the file should be opened for reading, writing or both.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream OpenTextFile(string name, int mode) {
            return null;
        }

        /// <summary>
        /// Opens a file as ASCII text for reading or writing as specified.
        /// </summary>
        /// <param name="name">The name of the file to open.</param>
        /// <param name="mode">Whether the file should be opened for reading, writing or both.</param>
        /// <param name="create">True if a file is to be created, and false otherwise.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream OpenTextFile(string name, int mode, bool create) {
            return null;
        }

        /// <summary>
        /// Opens a file for reading or writing as specified.
        /// </summary>
        /// <param name="name">The name of the file to open.</param>
        /// <param name="mode">Whether the file should be opened for reading, writing or both.</param>
        /// <param name="create">True if a file is to be created, and false otherwise.</param>
        /// <param name="format">The format of the text in the file.</param>
        /// <returns>A TextStream object representing the file.</returns>
        [PreserveCase]
        public TextStream OpenTextFile(string name, FileMode mode, bool create, FileFormat format) {
            return null;
        }
    }
}
