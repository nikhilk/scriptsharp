// FeedItemCollection.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.Feeds {

    [IgnoreNamespace]
    [Imported]
    public sealed class FeedItemCollection {

        private FeedItemCollection() {
        }

        [IntrinsicProperty]
        public int Count {
            get {
                return 0;
            }
        }

        public FeedItem Item(int index) {
            return null;
        }
    }
}
