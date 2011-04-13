// ApplicationCacheEvent.cs
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
    /// Represents an event raised by the Application Cache.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    [NamedValues]
    public enum ApplicationCacheEvent {

        /// <summary>
        /// Raised when the update process finishes for the first time
        /// </summary>
        [ScriptName("oncached")]
        OnCached,

        /// <summary>
        /// Raised when the cache update process begins.
        /// </summary>
        [ScriptName("onchecking")]
        OnChecking,

        /// <summary>
        /// Raised when the update process begins downloading resources
        /// in the manifest file.
        /// </summary>
        [ScriptName("ondownloading")]
        OnDownloading,

        /// <summary>
        /// Raised when an error occurs.
        /// </summary>
        [ScriptName("onerror")]
        OnError,

        /// <summary>
        /// Raised when the update process finishes but the manifest
        /// file does not change.
        /// </summary>
        [ScriptName("onnoupdate")]
        OnNoUpdate,

        /// <summary>
        /// Raised when each resource in the manifest file begins to download.
        /// </summary>
        [ScriptName("onprogress")]
        OnProgress,

        /// <summary>
        /// Raised when there is an existing application cache,
        /// the update process finishes, and there is a new application
        /// cache ready for use.
        /// </summary>
        [ScriptName("onupdateready")]
        OnUpdateReady
    }
}
