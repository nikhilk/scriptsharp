// ProgressBarEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by ProgressBar.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ProgressBarEvents {

        /// <summary>
        /// This event is triggered when the value of the progressbar changes.
        /// </summary>
        Change,

        /// <summary>
        /// This event is triggered when the value of the progressbar reaches the maximum value of 100.
        /// </summary>
        Complete,

        /// <summary>
        /// This event is triggered when the progressbar is created.
        /// </summary>
        Create
    }
}
