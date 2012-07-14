// DialogOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize Dialog.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DialogOptions {

        public DialogOptions() {
        }

        public DialogOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered when a dialog attempts to close. If the beforeClose event handler (callback function) returns false, the close will be prevented.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> BeforeClose {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the dialog is closed.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Close {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the dialog is created.
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
        /// This event is triggered when the dialog is dragged.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogDragEvent> Drag {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered at the beginning of the dialog being dragged.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogDragStartEvent> DragStart {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered after the dialog has been dragged.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogDragStopEvent> DragStop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the dialog gains focus.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Focus {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when dialog is opened.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Open {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the dialog is resized.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogResizeEvent> Resize {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered at the beginning of the dialog being resized.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogResizeStartEvent> ResizeStart {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered after the dialog has been resized.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<DialogResizeStopEvent> ResizeStop {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// When ''autoOpen'' is ''true'' the dialog will open automatically when ''dialog'' is called. If ''false'' it will stay hidden until ''.dialog("open")'' is called on it.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoOpen {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies which buttons should be displayed on the dialog. Each element of the array must be an Object defining the properties to set on the button.
        /// </summary>
        [IntrinsicProperty]
        public Array Buttons {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.
        /// </summary>
        [IntrinsicProperty]
        public bool CloseOnEscape {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.
        /// </summary>
        [IntrinsicProperty]
        public string CloseText {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The specified class name(s) will be added to the dialog, for additional theming.
        /// </summary>
        [IntrinsicProperty]
        public string DialogClass {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the dialog if set to true.
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
        /// If set to true, the dialog will be draggable by the titlebar.
        /// </summary>
        [IntrinsicProperty]
        public bool Draggable {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The height of the dialog, in pixels. Specifying 'auto' is also supported to make the dialog adjust based on its content.
        /// </summary>
        [IntrinsicProperty]
        public int Height {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The effect to be used when the dialog is closed.
        /// </summary>
        [IntrinsicProperty]
        public object Hide {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The maximum height to which the dialog can be resized, in pixels.
        /// </summary>
        [IntrinsicProperty]
        public int MaxHeight {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The maximum width to which the dialog can be resized, in pixels.
        /// </summary>
        [IntrinsicProperty]
        public int MaxWidth {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The minimum height to which the dialog can be resized, in pixels.
        /// </summary>
        [IntrinsicProperty]
        public int MinHeight {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The minimum width to which the dialog can be resized, in pixels.
        /// </summary>
        [IntrinsicProperty]
        public int MinWidth {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.
        /// </summary>
        [IntrinsicProperty]
        public bool Modal {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies where the dialog should be displayed. Possible values: <br />1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. <br />2) an array containing an <em>x,y</em> coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) <br />3) an array containing <em>x,y</em> position string values (e.g. ['right','top'] for top right corner).
        /// </summary>
        [IntrinsicProperty]
        public object Position {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true, the dialog will be resizable.
        /// </summary>
        [IntrinsicProperty]
        public bool Resizable {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The effect to be used when the dialog is opened.
        /// </summary>
        [IntrinsicProperty]
        public object Show {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.
        /// </summary>
        [IntrinsicProperty]
        public bool Stack {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.
        /// </summary>
        [IntrinsicProperty]
        public string Title {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The width of the dialog, in pixels.
        /// </summary>
        [IntrinsicProperty]
        public int Width {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// The starting z-index for the dialog.
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
