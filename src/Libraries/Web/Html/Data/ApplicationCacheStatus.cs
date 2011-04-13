// ApplicationCacheStatus.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    /// <summary>
    /// Indicates the status of the application cache.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [NumericValues]
    public enum ApplicationCacheStatus {

        /// <summary>
        /// The object isn’t associated with an application cache.
        /// </summary>
        Uncached = 0,

        /// <summary>
        /// The cache is idle, i.e. there are no outstanding checks or
        /// downloads in progress.
        /// </summary>
        Idle = 1,

        /// <summary>
        /// The update has started but the resources are not downloaded yet.
        /// </summary>
        Checking = 2,

        /// <summary>
        /// The resources are being downloaded into the cache.
        /// </summary>
        Downloading = 3,

        /// <summary>
        /// Resources have finished downloading and the new cache
        /// is ready to be used.
        /// </summary>
        UpdateReady = 4
    }
}
