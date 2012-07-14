// DialogEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by Dialog.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DialogEvents {

        /// <summary>
        /// This event is triggered when a dialog attempts to close. If the beforeClose event handler (callback function) returns false, the close will be prevented.
        /// </summary>
        BeforeClose,

        /// <summary>
        /// This event is triggered when the dialog is closed.
        /// </summary>
        Close,

        /// <summary>
        /// This event is triggered when the dialog is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered when the dialog is dragged.
        /// </summary>
        Drag,

        /// <summary>
        /// This event is triggered at the beginning of the dialog being dragged.
        /// </summary>
        DragStart,

        /// <summary>
        /// This event is triggered after the dialog has been dragged.
        /// </summary>
        DragStop,

        /// <summary>
        /// This event is triggered when the dialog gains focus.
        /// </summary>
        Focus,

        /// <summary>
        /// This event is triggered when dialog is opened.
        /// </summary>
        Open,

        /// <summary>
        /// This event is triggered when the dialog is resized.
        /// </summary>
        Resize,

        /// <summary>
        /// This event is triggered at the beginning of the dialog being resized.
        /// </summary>
        ResizeStart,

        /// <summary>
        /// This event is triggered after the dialog has been resized.
        /// </summary>
        ResizeStop
    }
}
