// DroppableEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Events raised by Droppable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DroppableEvents {

        /// <summary>
        /// This event is triggered any time an accepted draggable starts dragging. This can be useful if you want to make the droppable 'light up' when it can be dropped on.
        /// </summary>
        Activate,

        /// <summary>
        /// This event is triggered when the droppable is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered any time an accepted draggable stops dragging.
        /// </summary>
        Deactivate,

        /// <summary>
        /// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.ui.draggable represents the draggable.
        /// </summary>
        Drop,

        /// <summary>
        /// This event is triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
        /// </summary>
        Out,

        /// <summary>
        /// This event is triggered as an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
        /// </summary>
        Over
    }
}
