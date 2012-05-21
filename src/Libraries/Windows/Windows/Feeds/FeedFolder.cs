// FeedFolder.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    public sealed class FeedFolder {

        private FeedFolder() {
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedCollection Feeds {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public bool IsRoot {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedFolder Parent {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Path {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedFolderCollection Subfolders {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int TotalItemCount {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int TotalUnreadItemCount {
            get {
                return 0;
            }
        }

        [PreserveCase]
        public Feed CreateFeed(string feedName, string feedUrl) {
            return null;
        }

        [PreserveCase]
        public FeedFolder CreateSubfolder(string name) {
            return null;
        }

        [PreserveCase]
        public void Delete() {
        }

        [PreserveCase]
        public bool ExistsFeed(string name) {
            return false;
        }

        [PreserveCase]
        public bool ExistsSubfolder(string name) {
            return false;
        }

        [PreserveCase]
        public void Move(string newParentPath) {
        }

        [PreserveCase]
        public void Rename(string name) {
        }
    }
}
