// Drive.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Provides access to properties of a drive or network share.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class Drive {

        private Drive() {
        }

        /// <summary>
        /// Gets the amount of space available to a user on the this drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int AvailableSpace {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets the drive letter associated with this drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string DriveLetter {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the drive type associated with this drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public DriveType DriveType {
            get {
                return DriveType.Unknown;
            }
        }

        /// <summary>
        /// Gets the file system type associated with this drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string FileSystem {
            get {
                return null;
            }
        }

        /// <summary>
        /// Whether or not the drive is ready to be accessed.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public bool IsReady {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the path associated with the drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string Path {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the top-level folder associated with the drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public Folder RootFolder {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the serial number associated with the drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string SerialNumber {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the share name associated with the drive representing a network share.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string ShareName {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the amount of space in bytes on this drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int TotalSize {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the volume label associated with the drive.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public string VolumeName {
            get {
                return null;
            }
            set {
            }
        }
    }
}
