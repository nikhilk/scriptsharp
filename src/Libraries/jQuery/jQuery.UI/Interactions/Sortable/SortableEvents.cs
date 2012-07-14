// SortableEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Events raised by Sortable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SortableEvents {

        /// <summary>
        /// This event is triggered when using connected lists, every connected list on drag start receives it.
        /// </summary>
        Activate,

        /// <summary>
        /// This event is triggered when sorting stops, but when the placeholder/helper is still available.
        /// </summary>
        BeforeStop,

        /// <summary>
        /// This event is triggered during sorting, but only when the DOM position has changed.
        /// </summary>
        Change,

        /// <summary>
        /// This event is triggered when the sortable is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered when sorting was stopped, is propagated to all possible connected lists.
        /// </summary>
        Deactivate,

        /// <summary>
        /// This event is triggered when a sortable item is moved away from a connected list.
        /// </summary>
        Out,

        /// <summary>
        /// This event is triggered when a sortable item is moved into a connected list.
        /// </summary>
        Over,

        /// <summary>
        /// This event is triggered when a connected sortable list has received an item from another list.
        /// </summary>
        Receive,

        /// <summary>
        /// This event is triggered when a sortable item has been dragged out from the list and into another.
        /// </summary>
        Remove,

        /// <summary>
        /// This event is triggered during sorting.
        /// </summary>
        Sort,

        /// <summary>
        /// This event is triggered when sorting starts.
        /// </summary>
        Start,

        /// <summary>
        /// This event is triggered when sorting has stopped.
        /// </summary>
        Stop,

        /// <summary>
        /// This event is triggered when the user stopped sorting and the DOM position has changed.
        /// </summary>
        Update
    }
}
