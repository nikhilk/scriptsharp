// DraggableOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options used to initialize or customize Draggable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DraggableOptions {

        public DraggableOptions() {
        }

        public DraggableOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered when the draggable is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the mouse is moved during the dragging.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DragEvent> Drag {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when dragging starts.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DragStartEvent> Start {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when dragging stops.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DragStopEvent> Stop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// If set to false, will prevent the <code>ui-draggable</code> class from being added. This may be desired as a performance optimization when calling <code>.draggable()</code> init on many hundreds of elements.
        /// </summary>
        [IntrinsicProperty]
        public bool AddClasses {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The element passed to or selected by the <code>appendTo</code> option will be used as the draggable helper's container during dragging. By default, the helper is appended to the same container as the draggable.
        /// </summary>
        [IntrinsicProperty]
        public object AppendTo {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Constrains dragging to either the horizontal (x) or vertical (y) axis. Possible values: 'x', 'y'.
        /// </summary>
        [IntrinsicProperty]
        public string Axis {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Prevents dragging from starting on specified elements.
        /// </summary>
        [IntrinsicProperty]
        public string Cancel {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Allows the draggable to be dropped onto the specified sortables. If this option is used (<code>helper</code> must be set to 'clone' in order to work flawlessly), a draggable can be dropped onto a sortable list and then becomes part of it.
        /// </summary>
        [IntrinsicProperty]
        public string ConnectToSortable {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Constrains dragging to within the bounds of the specified element or region. Possible string values: 'parent', 'document', 'window', [x1, y1, x2, y2].
        /// </summary>
        [IntrinsicProperty]
        public object Containment {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The css cursor during the drag operation.
        /// </summary>
        [IntrinsicProperty]
        public string Cursor {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Sets the offset of the dragging helper relative to the mouse cursor. Coordinates can be given as a hash using a combination of one or two keys: <code>{ top, left, right, bottom }</code>.
        /// </summary>
        [IntrinsicProperty]
        public object CursorAt {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Time in milliseconds after mousedown until dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
        /// </summary>
        [IntrinsicProperty]
        public int Delay {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the draggable if set to true.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Distance in pixels after mousedown the mouse must move before dragging should start. This option can be used to prevent unwanted drags when clicking on an element.
        /// </summary>
        [IntrinsicProperty]
        public int Distance {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Snaps the dragging helper to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        [IntrinsicProperty]
        public Array Grid {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If specified, restricts drag start click to the specified element(s).
        /// </summary>
        [IntrinsicProperty]
        public object Handle {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Allows for a helper element to be used for dragging display. Possible values: 'original', 'clone', Function. If a function is specified, it must return a DOMElement.
        /// </summary>
        [IntrinsicProperty]
        public object Helper {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Prevent iframes from capturing the mousemove events during a drag. Useful in combination with cursorAt, or in any case, if the mouse cursor is not over the helper. If set to true, transparent overlays will be placed over all iframes on the page. If a selector is supplied, the matched iframes will have an overlay placed over them.
        /// </summary>
        [IntrinsicProperty]
        public object IframeFix {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Opacity for the helper while being dragged.
        /// </summary>
        [IntrinsicProperty]
        public int Opacity {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, all droppable positions are calculated on every mousemove. Caution: This solves issues on highly dynamic pages, but dramatically decreases performance.
        /// </summary>
        [IntrinsicProperty]
        public bool RefreshPositions {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, the element will return to its start position when dragging stops. Possible string values: 'valid', 'invalid'. If set to invalid, revert will only occur if the draggable has not been dropped on a droppable. For valid, it's the other way around.
        /// </summary>
        [IntrinsicProperty]
        public object Revert {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The duration of the revert animation, in milliseconds. Ignored if revert is false.
        /// </summary>
        [IntrinsicProperty]
        public int RevertDuration {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted by the droppable.
        /// </summary>
        [IntrinsicProperty]
        public string Scope {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, container auto-scrolls while dragging.
        /// </summary>
        [IntrinsicProperty]
        public bool Scroll {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Distance in pixels from the edge of the viewport after which the viewport should scroll. Distance is relative to pointer, not the draggable.
        /// </summary>
        [IntrinsicProperty]
        public int ScrollSensitivity {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The speed at which the window should scroll once the mouse pointer gets within the <code>scrollSensitivity</code> distance.
        /// </summary>
        [IntrinsicProperty]
        public int ScrollSpeed {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// If set to a selector or to true (equivalent to '.ui-draggable'), the draggable will snap to the edges of the selected elements when near an edge of the element.
        /// </summary>
        [IntrinsicProperty]
        public object Snap {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Determines which edges of snap elements the draggable will snap to. Ignored if snap is false. Possible values: 'inner', 'outer', 'both'
        /// </summary>
        [IntrinsicProperty]
        public string SnapMode {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The distance in pixels from the snap element edges at which snapping should occur. Ignored if snap is false.
        /// </summary>
        [IntrinsicProperty]
        public int SnapTolerance {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Controls the z-Index of the set of elements that match the selector, always brings to front the dragged item. Very useful in things like window managers.
        /// </summary>
        [IntrinsicProperty]
        public string Stack {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// z-index for the helper while being dragged.
        /// </summary>
        [IntrinsicProperty]
        public int ZIndex {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
