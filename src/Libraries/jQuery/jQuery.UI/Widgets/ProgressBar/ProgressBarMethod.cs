// ProgressBarMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by ProgressBar.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ProgressBarMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// This method gets or sets the current value of the progressbar.
        /// </summary>
        Value,

        Widget
    }
}
