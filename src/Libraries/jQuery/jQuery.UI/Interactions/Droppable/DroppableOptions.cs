// DroppableOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options used to initialize or customize Droppable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DroppableOptions {

        public DroppableOptions() {
        }

        public DroppableOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered any time an accepted draggable starts dragging. This can be useful if you want to make the droppable 'light up' when it can be dropped on.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DropActivateEvent> Activate {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the droppable is created.
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
        /// This event is triggered any time an accepted draggable stops dragging.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DropDeactivateEvent> Deactivate {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable. In the callback, $(this) represents the droppable the draggable is dropped on.ui.draggable represents the draggable.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DropEvent> Drop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Out {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered as an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DropOverEvent> Over {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// All draggables that match the selector will be accepted. If a function is specified, the function will be called for each draggable on the page (passed as the first argument to the function), to provide a custom filter. The function should return true if the draggable should be accepted.
        /// </summary>
        [IntrinsicProperty]
        public object Accept {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being dragged.
        /// </summary>
        [IntrinsicProperty]
        public string ActiveClass {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to false, will prevent the ui-droppable class from being added. This may be desired as a performance optimization when calling .droppable() init on many hundreds of elements.
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
        /// Disables the droppable if set to true.
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
        /// If true, will prevent event propagation on nested droppables.
        /// </summary>
        [IntrinsicProperty]
        public bool Greedy {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// If specified, the class will be added to the droppable while an acceptable draggable is being hovered.
        /// </summary>
        [IntrinsicProperty]
        public string HoverClass {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Used to group sets of draggable and droppable items, in addition to droppable's accept option. A draggable with the same scope value as a droppable will be accepted.
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
        /// Specifies which mode to use for testing whether a draggable is 'over' a droppable. Possible values: 'fit', 'intersect', 'pointer', 'touch'.<ul><li>'''fit''': draggable overlaps the droppable entirely</li><li>'''intersect''': draggable overlaps the droppable at least 50%</li><li>'''pointer''': mouse pointer overlaps the droppable</li><li>'''touch''': draggable overlaps the droppable any amount</li></ul>
        /// </summary>
        [IntrinsicProperty]
        public string Tolerance {
            get {
                return null;
            }
            set {
            }
        }
    }
}
