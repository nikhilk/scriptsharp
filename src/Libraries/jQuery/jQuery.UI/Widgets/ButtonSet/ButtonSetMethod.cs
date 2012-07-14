// ButtonSetMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by ButtonSet.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ButtonSetMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// Refreshes the visual state of the button. Useful for updating button state after the native element's checked or disabled state is changed programatically.
        /// </summary>
        Refresh,

        Widget
    }
}
