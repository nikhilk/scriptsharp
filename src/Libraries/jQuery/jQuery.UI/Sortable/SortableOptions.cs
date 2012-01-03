// SortableOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Sortable
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
    public sealed class SortableOptions
    {
        public SortableOptions() { }
        public SortableOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when sortable is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when sorting starts.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Start { get { return null; } set { } }

        /// <summary>
        /// This event is triggered during sorting.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Sort { get { return null; } set { } }

        /// <summary>
        /// This event is triggered during sorting, but only when the DOM position has changed.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Change { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when sorting stops, but when the placeholder/helper is still available.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler BeforeStop { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when sorting has stopped.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Stop { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when the user stopped sorting and the DOM position has changed.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Update { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a connected sortable list has received an item from another list.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Receive { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a sortable item has been dragged out from the list and into another.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Remove { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a sortable item is moved into a connected list.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Over { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a sortable item is moved away from a connected list.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Out { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when using connected lists, every connected list on drag start receives it.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Activate { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when sorting was stopped, is propagated to all possible connected lists.
        /// </summary>
        [IntrinsicProperty]
        public SortableEventHandler Deactivate { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the sortable. Can be set when initialising (first creating) the sortable.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// Defines where the helper that moves with the mouse is being appended to during the drag (for example, to resolve overlap/zIndex issues).
        /// </summary>
        [IntrinsicProperty]
        public string AppendTo { get { return null; } set { } }

        /// <summary>
        /// If defined, the items can be dragged only horizontally or vertically. Possible values:<c>'x', 'y'</c>.
        /// </summary>
        [IntrinsicProperty]
        public string Axis { get { return null; } set { } }

        /// <summary>
        /// Prevents sorting if you start on elements matching the selector.
        /// </summary>
        [IntrinsicProperty]
        public string Cancel { get { return null; } set { } }

        /// <summary>
        /// Takes a jQuery selector with items that also have sortables applied. If used, the sortable is now connected to the other one-way, so you can drag from this sortable to the other.
        /// </summary>
        [IntrinsicProperty]
        public string ConnectWith { get { return null; } set { } }

        /// <summary>
        /// Constrains dragging to within the bounds of the specified element - can be a DOM element, 'parent', 'document', 'window', or a jQuery selector.Note: the element specified for containment must have a calculated width and height (though it need not be explicit), so for example, if you have float:left sortable children and specify containment:'parent' be sure to have float:left on the sortable/parent container as well or it will have height: 0, causing undefined behavior.
        /// </summary>
        [IntrinsicProperty]
        public object Containment { get { return null; } set { } }

        /// <summary>
        /// Defines the cursor that is being shown while sorting.
        /// </summary>
        [IntrinsicProperty]
        public string Cursor { get { return null; } set { } }

        /// <summary>
        /// Moves the sorting element or helper so the cursor always appears to drag from the same position. Coordinates can be given as a hash using a combination of one or two keys: <code>{ top, left, right, bottom }</code>.
        /// </summary>
        [IntrinsicProperty]
        public object CursorAt { get { return null; } set { } }

        /// <summary>
        /// Time in milliseconds to define when the sorting should start. It helps preventing unwanted drags when clicking on an element.
        /// </summary>
        [IntrinsicProperty]
        public int Delay { get { return 0; } set { } }

        /// <summary>
        /// Tolerance, in pixels, for when sorting should start. If specified, sorting will not start until after mouse is dragged beyond distance. Can be used to allow for clicks on elements within a handle.
        /// </summary>
        [IntrinsicProperty]
        public int Distance { get { return 0; } set { } }

        /// <summary>
        /// If false items from this sortable can't be dropped to an empty linked sortable.
        /// </summary>
        [IntrinsicProperty]
        public bool DropOnEmpty { get { return false; } set { } }

        /// <summary>
        /// If true, forces the helper to have a size.
        /// </summary>
        [IntrinsicProperty]
        public bool ForceHelperSize { get { return false; } set { } }

        /// <summary>
        /// If true, forces the placeholder to have a size.
        /// </summary>
        [IntrinsicProperty]
        public bool ForcePlaceholderSize { get { return false; } set { } }

        /// <summary>
        /// Snaps the sorting element or helper to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        [IntrinsicProperty]
        public Array Grid { get { return null; } set { } }

        /// <summary>
        /// Restricts sort start click to the specified element.
        /// </summary>
        [IntrinsicProperty]
        public object Handle { get { return null; } set { } }

        /// <summary>
        /// Allows for a helper element to be used for dragging display. The supplied function receives the event and the element being sorted, and should return a DOMElement to be used as a custom proxy helper. Possible values: 'original', 'clone'
        /// </summary>
        [IntrinsicProperty]
        public object Helper { get { return null; } set { } }

        /// <summary>
        /// Specifies which items inside the element should be sortable.
        /// </summary>
        [IntrinsicProperty]
        public string Items { get { return null; } set { } }

        /// <summary>
        /// Defines the opacity of the helper while sorting. From 0.01 to 1
        /// </summary>
        [IntrinsicProperty]
        public float Opacity { get { return 0; } set { } }

        /// <summary>
        /// Class that gets applied to the otherwise white space.
        /// </summary>
        [IntrinsicProperty]
        public string Placeholder { get { return null; } set { } }

        /// <summary>
        /// If set to true, the item will be reverted to its new DOM position with a smooth animation. Optionally, it can also be set to a number that controls the duration of the animation in ms.
        /// </summary>
        [IntrinsicProperty]
        public object Revert { get { return null; } set { } }

        /// <summary>
        /// If set to true, the page scrolls when coming to an edge.
        /// </summary>
        [IntrinsicProperty]
        public bool Scroll { get { return false; } set { } }

        /// <summary>
        /// Defines how near the mouse must be to an edge to start scrolling.
        /// </summary>
        [IntrinsicProperty]
        public int ScrollSensitivity { get { return 0; } set { } }

        /// <summary>
        /// The speed at which the window should scroll once the mouse pointer gets within the scrollSensitivity distance.
        /// </summary>
        [IntrinsicProperty]
        public int ScrollSpeed { get { return 0; } set { } }

        /// <summary>
        /// This is the way the reordering behaves during drag. Possible values: 'intersect', 'pointer'. In some setups, 'pointer' is more natural.
        /// </summary>
        [IntrinsicProperty]
        public string Tolerance { get { return null; } set { } }

        /// <summary>
        /// Z-index for element/helper while being sorted.
        /// </summary>
        [IntrinsicProperty]
        public int ZIndex { get { return 0; } set { } }

        #endregion
    }
}
