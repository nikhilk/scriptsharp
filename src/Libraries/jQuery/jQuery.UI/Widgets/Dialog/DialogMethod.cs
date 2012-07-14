// DialogMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by Dialog.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DialogMethod {

        /// <summary>
        /// Close the dialog.
        /// </summary>
        Close,

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        /// <summary>
        /// Returns true if the dialog is currently open.
        /// </summary>
        IsOpen,

        /// <summary>
        /// Move the dialog to the top of the dialogs stack.
        /// </summary>
        MoveToTop,

        /// <summary>
        /// Open the dialog.
        /// </summary>
        Open,

        Option,

        Widget
    }
}
