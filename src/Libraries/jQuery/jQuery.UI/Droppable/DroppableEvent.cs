// DroppableEvent.cs
// Script#/Libraries/jQuery/jQuery.UI/Droppable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    public static class DroppableEvent
    {
        /// <summary>
        /// This event is triggered when droppable is created.
        /// </summary>
        public const string Create = "dropcreate";
        /// <summary>
        /// This event is triggered any time an accepted draggable starts dragging. This can be useful if you want to make the droppable 'light up' when it can be dropped on.
        /// </summary>
        public const string Activate = "dropactivate";
        /// <summary>
        /// This event is triggered any time an accepted draggable stops dragging.
        /// </summary>
        public const string Deactivate = "dropdeactivate";
        /// <summary>
        /// This event is triggered as an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
        /// </summary>
        public const string Over = "dropover";
        /// <summary>
        /// This event is triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
        /// </summary>
        public const string Out = "dropout";
        /// <summary>
        /// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.ui.draggable represents the draggable.
        /// </summary>
        public const string Drop = "drop";
    }
}
