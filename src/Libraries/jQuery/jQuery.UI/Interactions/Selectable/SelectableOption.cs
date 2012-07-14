// SelectableOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options for use with Selectable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SelectableOption {

        /// <summary>
        /// This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.
        /// </summary>
        AutoRefresh,

        /// <summary>
        /// Prevents selecting if you start on elements matching the selector.
        /// </summary>
        Cancel,

        /// <summary>
        /// Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.
        /// </summary>
        Delay,

        /// <summary>
        /// Disables the selectable if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.
        /// </summary>
        Distance,

        /// <summary>
        /// The matching child elements will be made selectees (able to be selected).
        /// </summary>
        Filter,

        /// <summary>
        /// Possible values: 'touch', 'fit'.<ul><li>'''fit''': draggable overlaps the droppable entirely</li><li>'''touch''': draggable overlaps the droppable any amount</li></ul>
        /// </summary>
        Tolerance
    }
}
