// FeedItem.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    public sealed class FeedItem {

        private FeedItem() {
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Author {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Comments {
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
        public FeedEnclosure Enclosure {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public string Guid {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public bool IsRead {
            get {
                return false;
            }
            set {
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
        public string Link {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int LocalId {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public int Modified {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        [PreserveCase]
        public Feed Parent {
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
        public string Title {
            get {
                return null;
            }
        }

        [PreserveCase]
        public void Delete() {
        }

        [PreserveCase]
        public string Xml(FeedXmlIncludeFlags flags) {
            return null;
        }
    }
}
