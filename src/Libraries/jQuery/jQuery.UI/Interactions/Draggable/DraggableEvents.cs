// DraggableEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Events raised by Draggable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DraggableEvents {

        /// <summary>
        /// This event is triggered when the draggable is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered when the mouse is moved during the dragging.
        /// </summary>
        Drag,

        /// <summary>
        /// This event is triggered when dragging starts.
        /// </summary>
        Start,

        /// <summary>
        /// This event is triggered when dragging stops.
        /// </summary>
        Stop
    }
}
