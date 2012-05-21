// FeedsManager.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    public sealed class FeedsManager {

        [IntrinsicProperty]
        [PreserveCase]
        public BackgroundSyncStatus BackgroundSyncStatus {
            get {
                return BackgroundSyncStatus.Enabled;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int DefaultInterval {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int ItemCountLimit {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public FeedFolder RootFolder {
            get {
                return null;
            }
        }

        [PreserveCase]
        public void AsyncSyncAll() {
        }

        [PreserveCase]
        public void BackgroundSync(BackgroundSyncAction action) {
        }

        [PreserveCase]
        public void DeleteFeed(string feedPath) {
        }

        [PreserveCase]
        public void DeleteFolder(string folderPath) {
        }

        [PreserveCase]
        public bool ExistsFeed(string name) {
            return false;
        }

        [PreserveCase]
        public bool ExistsFolder(string name) {
            return false;
        }

        [PreserveCase]
        public Feed GetFeed(string feedPath) {
            return null;
        }

        [PreserveCase]
        public Feed GetFeedByUrl(string feedUrl) {
            return null;
        }

        [PreserveCase]
        public FeedFolder GetFolder(string folderPath) {
            return null;
        }

        [PreserveCase]
        public bool IsSubscribed(string feedUrl) {
            return false;
        }

        [PreserveCase]
        public string Normalize(string feedXml) {
            return null;
        }
    }
}
