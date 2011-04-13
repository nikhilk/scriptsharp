// ApplicationCache.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [IgnoreNamespace]
    [Imported]
    public sealed class ApplicationCache {

        private ApplicationCache() {
        }

        /// <summary>
        /// Gets the current status of the application cache.
        /// </summary>
        [IntrinsicProperty]
        public ApplicationCacheStatus Status {
            get {
                return ApplicationCacheStatus.Uncached;
            }
        }

        public void Add(string uri) {
        }

        public void AddEventListener(ApplicationCacheEvent eventName, ElementEventListener listener, bool useCapture) {
        }

        public void RemoveEventListener(ApplicationCacheEvent eventName, ElementEventListener listener, bool useCapture) {
        }

        /// <summary>
        /// Replaces the active cache with the latest version.
        /// </summary>
        public void SwapCache() {
        }

        /// <summary>
        /// Manually triggers the update process.
        /// </summary>
        public void Update() {
        }
    }
}
