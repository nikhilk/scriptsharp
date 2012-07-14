// DroppableOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options for use with Droppable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DroppableOption {

        /// <summary>
        /// All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.
        /// </summary>
        Accept,

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being dragged.
        /// </summary>
        ActiveClass,

        /// <summary>
        /// If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.
        /// </summary>
        AddClasses,

        /// <summary>
        /// Disables the droppable if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// If true, will prevent event propagation on nested droppables.
        /// </summary>
        Greedy,

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being hovered.
        /// </summary>
        HoverClass,

        /// <summary>
        /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.
        /// </summary>
        Scope,

        /// <summary>
        /// Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.<ul><li>'''fit''': draggable overlaps the droppable entirely</li><li>'''intersect''': draggable overlaps the droppable at least 50%</li><li>'''pointer''': mouse pointer overlaps the droppable</li><li>'''touch''': draggable overlaps the droppable any amount</li></ul>
        /// </summary>
        Tolerance
    }
}
