// DroppableOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Droppable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DroppableOptions
    {
        public DroppableOptions() { }
        public DroppableOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when droppable is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered any time an accepted draggable starts dragging. This can be useful if you want to make the droppable 'light up' when it can be dropped on.
        /// </summary>
        [IntrinsicProperty]
        public DroppableEventHandler Activate { get { return null; } set { } }

        /// <summary>
        /// This event is triggered any time an accepted draggable stops dragging.
        /// </summary>
        [IntrinsicProperty]
        public DroppableEventHandler Deactivate { get { return null; } set { } }

        /// <summary>
        /// This event is triggered as an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
        /// </summary>
        [IntrinsicProperty]
        public DroppableEventHandler Over { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
        /// </summary>
        [IntrinsicProperty]
        public DroppableEventHandler Out { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.ui.draggable represents the draggable.
        /// </summary>
        [IntrinsicProperty]
        public DroppableEventHandler Drop { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the droppable. Can be set when initialising (first creating) the droppable.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.
        /// </summary>
        [IntrinsicProperty]
        public object Accept { get { return null; } set { } }

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being dragged.
        /// </summary>
        [IntrinsicProperty]
        public string ActiveClass { get { return null; } set { } }

        /// <summary>
        /// If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.
        /// </summary>
        [IntrinsicProperty]
        public bool AddClasses { get { return false; } set { } }

        /// <summary>
        /// If true, will prevent event propagation on nested droppables.
        /// </summary>
        [IntrinsicProperty]
        public bool Greedy { get { return false; } set { } }

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being hovered.
        /// </summary>
        [IntrinsicProperty]
        public string HoverClass { get { return null; } set { } }

        /// <summary>
        /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.
        /// </summary>
        [IntrinsicProperty]
        public string Scope { get { return null; } set { } }

        /// <summary>
        /// Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.
        /// </summary>
        [IntrinsicProperty]
        public string Tolerance { get { return null; } set { } }

        #endregion
    }
}
