// SortableOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options for use with Sortable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SortableOption {

        /// <summary>
        /// Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).
        /// </summary>
        AppendTo,

        /// <summary>
        /// If defined, the items can be dragged only horizontally or vertically. Possible values:'x', 'y'.
        /// </summary>
        Axis,

        /// <summary>
        /// Prevents sorting if you start on elements matching the selector.
        /// </summary>
        Cancel,

        /// <summary>
        /// Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.
        /// </summary>
        ConnectWith,

        /// <summary>
        /// Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector.<para>Note: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.</para>
        /// </summary>
        Containment,

        /// <summary>
        /// Defines the cursor that is being shown while sorting.
        /// </summary>
        Cursor,

        /// <summary>
        /// Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: <code>{ top, left, right, bottom }</code>.
        /// </summary>
        CursorAt,

        /// <summary>
        /// Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.
        /// </summary>
        Delay,

        /// <summary>
        /// Disables the sortable if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
        /// </summary>
        Distance,

        /// <summary>
        /// If false items from this sortable can't be dropped to an empty linked sortable.
        /// </summary>
        DropOnEmpty,

        /// <summary>
        /// If true, forces the helper to have a size.
        /// </summary>
        ForceHelperSize,

        /// <summary>
        /// If true, forces the placeholder to have a size.
        /// </summary>
        ForcePlaceholderSize,

        /// <summary>
        /// Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        Grid,

        /// <summary>
        /// Restricts sort start click to the specified element.
        /// </summary>
        Handle,

        /// <summary>
        /// Allows for a helper element to be used for dragging display. The supplied function receives the event and the element being sorted, and should return a DOMElement to be used as a custom proxy helper. Possible values: 'original', 'clone'
        /// </summary>
        Helper,

        /// <summary>
        /// Specifies which items inside the element should be sortable.
        /// </summary>
        Items,

        /// <summary>
        /// Defines the opacity of the helper while sorting. From 0.01 to 1
        /// </summary>
        Opacity,

        /// <summary>
        /// Class that gets applied to the otherwise white space.
        /// </summary>
        Placeholder,

        /// <summary>
        /// If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.
        /// </summary>
        Revert,

        /// <summary>
        /// If set to true, the page scrolls when coming to an edge.
        /// </summary>
        Scroll,

        /// <summary>
        /// Defines how near the mouse must be to an edge to start scrolling.
        /// </summary>
        ScrollSensitivity,

        /// <summary>
        /// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
        /// </summary>
        ScrollSpeed,

        /// <summary>
        /// This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.<ul><li>'''intersect''': draggable overlaps the droppable at least 50%</li><li>'''pointer''': mouse pointer overlaps the droppable</li></ul>
        /// </summary>
        Tolerance,

        /// <summary>
        /// Z-index for element/helper while being sorted.
        /// </summary>
        ZIndex
    }
}
