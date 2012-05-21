// Feed.cs
// Script#/Libraries/Windows
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    public sealed class Feed {

        private Feed() {
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Copyright {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Description {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public bool DownloadEnclosuresAutomatically {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public DownloadStatus DownloadStatus {
            get {
                return DownloadStatus.None;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string DownloadUrl {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Image {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int Interval {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public bool IsList {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int ItemCount {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedItemCollection Items {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Language {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int LastBuildDate {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int LastDownloadError {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int LastDownloadTime {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int LastWriteTime {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Link {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string LocalEnclosurePath {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string LocalId {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int MaxItemCount {
            get {
                return 0;
            }
            set {
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
        public int PubDate {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedSyncSetting SyncSetting {
            get {
                return FeedSyncSetting.Default;
            }
            set {
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Title {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int Ttl {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int UnreadItemCount {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Url {
            get {
                return null;
            }
            set {
            }
        }

        [PreserveCase]
        public void AsyncDownload() {
        }

        [PreserveCase]
        public void CancelAsyncDownload() {
        }

        [PreserveCase]
        public void Delete() {
        }

        [PreserveCase]
        public void Download() {
        }

        [PreserveCase]
        public FeedItem GetItem(int localID) {
            return null;
        }

        [PreserveCase]
        public void MarkAllItemsRead() {
        }

        [PreserveCase]
        public void Merge(string xml, string feedURL) {
        }

        [PreserveCase]
        public void Move(string path) {
        }

        [PreserveCase]
        public string Xml(int count, FeedSortProperty sortProperty, FeedSortOrder sortOrder, FeedFilterFlags filterFlags, FeedXmlIncludeFlags includeFlags) {
            return null;
        }
    }
}
