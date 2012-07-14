// DraggableOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options for use with Draggable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DraggableOption {

        /// <summary>
        /// If set to false, will prevent the <code>ui-draggable</code> class from being added. This may be desired as a performance optimization when calling <code>.draggable()</code> init on many hundreds of elements.
        /// </summary>
        AddClasses,

        /// <summary>
        /// The element passed to or selected by the <code>appendTo</code> option will be used as the draggable helper's container during dragging. By default, the helper is appended to the same container as the draggable.
        /// </summary>
        AppendTo,

        /// <summary>
        /// Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: 'x', 'y'.
        /// </summary>
        Axis,

        /// <summary>
        /// Prevents dragging from starting on specified elements.
        /// </summary>
        Cancel,

        /// <summary>
        /// Allows the draggable to be dropped onto the specified sortables. If this option is used (<code>helper</code> must be set to 'clone' in order to work flawlessly), a draggable can be dropped onto a sortable list and then becomes part of it.
        /// </summary>
        ConnectToSortable,

        /// <summary>
        /// Constrains dragging to within the bounds of the specified element or region. Possible string values: 'parent', 'document', 'window', [x1, y1, x2, y2].
        /// </summary>
        Containment,

        /// <summary>
        /// The css cursor during the drag operation.
        /// </summary>
        Cursor,

        /// <summary>
        /// Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: <code>{ top, left, right, bottom }</code>.
        /// </summary>
        CursorAt,

        /// <summary>
        /// Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
        /// </summary>
        Delay,

        /// <summary>
        /// Disables the draggable if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
        /// </summary>
        Distance,

        /// <summary>
        /// Snaps the dragging helper to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        Grid,

        /// <summary>
        /// If specified, restricts drag start click to the specified element(s).
        /// </summary>
        Handle,

        /// <summary>
        /// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone', Function. If a function is specified, it must return a DOMElement.
        /// </summary>
        Helper,

        /// <summary>
        /// Prevent iframes from capturing the mousemove events during a drag. Useful in combination with cursorAt, or in any case, if the mouse cursor is not over the helper. If set to true, transparent overlays will be placed over all iframes on the page. If a selector is supplied, the matched iframes will have an overlay placed over them.
        /// </summary>
        IframeFix,

        /// <summary>
        /// Opacity for the helper while being dragged.
        /// </summary>
        Opacity,

        /// <summary>
        /// If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.
        /// </summary>
        RefreshPositions,

        /// <summary>
        /// If set to true, the element will return to its start position when dragging stops. Possible string values: 'valid', 'invalid'. If set to invalid, revert will only occur if the draggable has not been dropped on a droppable. For valid, it's the other way around.
        /// </summary>
        Revert,

        /// <summary>
        /// The duration of the revert animation, in milliseconds. Ignored if revert is false.
        /// </summary>
        RevertDuration,

        /// <summary>
        /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.
        /// </summary>
        Scope,

        /// <summary>
        /// If set to true, container auto-scrolls while dragging.
        /// </summary>
        Scroll,

        /// <summary>
        /// Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable.
        /// </summary>
        ScrollSensitivity,

        /// <summary>
        /// The speed at which the window should scroll once the mouse pointer gets within the <code>scrollSensitivity</code> distance.
        /// </summary>
        ScrollSpeed,

        /// <summary>
        /// If set to a selector or to true (equivalent to '.ui-draggable'), the draggable will snap to the edges of the selected elements when near an edge of the element.
        /// </summary>
        Snap,

        /// <summary>
        /// Determines which edges of snap elements the draggable will snap to. Ignored if snap is false. Possible values: 'inner', 'outer', 'both'
        /// </summary>
        SnapMode,

        /// <summary>
        /// The distance in pixels from the snap element edges at which snapping should occur. Ignored if snap is false.
        /// </summary>
        SnapTolerance,

        /// <summary>
        /// Controls the z-Index of the set of elements that match the selector, always brings to front the dragged item. Very useful in things like window managers.
        /// </summary>
        Stack,

        /// <summary>
        /// z-index for the helper while being dragged.
        /// </summary>
        ZIndex
    }
}
