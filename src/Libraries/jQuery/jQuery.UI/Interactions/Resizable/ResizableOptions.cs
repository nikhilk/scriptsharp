// ResizableOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Options used to initialize or customize Resizable.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ResizableOptions {

        public ResizableOptions() {
        }

        public ResizableOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered when the resizable is created.
        /// </summary>
        [ScriptField]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered during the resize, on the drag of the resize handler.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<ResizeEvent> Resize {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered at the start of a resize operation.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<ResizeStartEvent> Start {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered at the end of a resize operation.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<ResizeStopEvent> Stop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Resize these elements synchronous when resizing.
        /// </summary>
        [ScriptField]
        public object AlsoResize {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Animates to the final size after resizing.
        /// </summary>
        [ScriptField]
        public bool Animate {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.
        /// </summary>
        [ScriptField]
        public object AnimateDuration {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Easing effect for animating.
        /// </summary>
        [ScriptField]
        public string AnimateEasing {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.
        /// </summary>
        [ScriptField]
        public object AspectRatio {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, automatically hides the handles except when the mouse hovers over the element.
        /// </summary>
        [ScriptField]
        public bool AutoHide {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Prevents resizing if you start on elements matching the selector.
        /// </summary>
        [ScriptField]
        public string Cancel {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.
        /// </summary>
        [ScriptField]
        public object Containment {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.
        /// </summary>
        [ScriptField]
        public int Delay {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the resizable if set to true.
        /// </summary>
        [ScriptField]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.
        /// </summary>
        [ScriptField]
        public int Distance {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, a semi-transparent helper element is shown for resizing.
        /// </summary>
        [ScriptField]
        public bool Ghost {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]
        /// </summary>
        [ScriptField]
        public Array Grid {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin.<para>If specified as an object, the following keys are supported: { n, e, s, w, ne, se, sw, nw }. The value of any specified should be a jQuery selector matching the child element of the resizable to use as that handle. If the handle is not a child of the resizable, you can pass in the DOMElement or a valid jQuery object directly.</para>
        /// </summary>
        [ScriptField]
        public object Handles {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// This is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.
        /// </summary>
        [ScriptField]
        public string Helper {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// This is the maximum height the resizable should be allowed to resize to.
        /// </summary>
        [ScriptField]
        public int MaxHeight {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// This is the maximum width the resizable should be allowed to resize to.
        /// </summary>
        [ScriptField]
        public int MaxWidth {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// This is the minimum height the resizable should be allowed to resize to.
        /// </summary>
        [ScriptField]
        public int MinHeight {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// This is the minimum width the resizable should be allowed to resize to.
        /// </summary>
        [ScriptField]
        public int MinWidth {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
