// SelectableEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Events raised by Selectable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SelectableEvents {

        /// <summary>
        /// This event is triggered when the selectable is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered at the end of the select operation, on each element added to the selection.
        /// </summary>
        Selected,

        /// <summary>
        /// This event is triggered during the select operation, on each element added to the selection.
        /// </summary>
        Selecting,

        /// <summary>
        /// This event is triggered at the beginning of the select operation.
        /// </summary>
        Start,

        /// <summary>
        /// This event is triggered at the end of the select operation.
        /// </summary>
        Stop,

        /// <summary>
        /// This event is triggered at the end of the select operation, on each element removed from the selection.
        /// </summary>
        Unselected,

        /// <summary>
        /// This event is triggered during the select operation, on each element removed from the selection.
        /// </summary>
        Unselecting
    }
}
