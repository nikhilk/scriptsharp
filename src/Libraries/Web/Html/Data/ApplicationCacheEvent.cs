// ApplicationCacheEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
        [ScriptName("cached")]
        Cached,

        /// <summary>
        /// Raised when the cache update process begins.
        /// </summary>
        [ScriptName("checking")]
        Checking,

        /// <summary>
        /// Raised when the update process begins downloading resources
        /// in the manifest file.
        /// </summary>
        [ScriptName("downloading")]
        Downloading,

        /// <summary>
        /// Raised when an error occurs.
        /// </summary>
        [ScriptName("error")]
        Error,

        /// <summary>
        /// Raised when the update process finishes but the manifest
        /// file does not change.
        /// </summary>
        [ScriptName("noupdate")]
        NoUpdate,

        /// <summary>
        /// Raised when each resource in the manifest file begins to download.
        /// </summary>
        [ScriptName("progress")]
        Progress,

        /// <summary>
        /// Raised when there is an existing application cache,
        /// the update process finishes, and there is a new application
        /// cache ready for use.
        /// </summary>
        [ScriptName("updateready")]
        UpdateReady
    }
}
