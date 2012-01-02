// DialogOption.cs
// Script#/Libraries/jQuery/jQuery.UI/Dialog
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DialogOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the dialog. Can be set when initialising (first creating) the dialog.
        /// </summary>
        Disabled,
        /// <summary>
        /// When ''autoOpen'' is ''true'' the dialog will open automatically when ''dialog'' is called. If ''false'' it will stay hidden until ''.dialog("open")'' is called on it.
        /// </summary>
        AutoOpen,
        /// <summary>
        /// Specifies which buttons should be displayed on the dialog. The property key is the text of the button. The value is the callback function for when the button is clicked.  The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.
        /// </summary>
        Buttons,
        /// <summary>
        /// Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.
        /// </summary>
        CloseOnEscape,
        /// <summary>
        /// Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.
        /// </summary>
        CloseText,
        /// <summary>
        /// The specified class name(s) will be added to the dialog, for additional theming.
        /// </summary>
        DialogClass,
        /// <summary>
        /// If set to true, the dialog will be draggable will be draggable by the titlebar.
        /// </summary>
        Draggable,
        /// <summary>
        /// The height of the dialog, in pixels. Specifying <c>'auto'</c> is also supported to make the dialog adjust based on its content.
        /// </summary>
        Height,
        /// <summary>
        /// The effect to be used when the dialog is closed.
        /// </summary>
        Hide,
        /// <summary>
        /// The maximum height to which the dialog can be resized, in pixels.
        /// </summary>
        MaxHeight,
        /// <summary>
        /// The maximum width to which the dialog can be resized, in pixels.
        /// </summary>
        MaxWidth,
        /// <summary>
        /// The minimum height to which the dialog can be resized, in pixels.
        /// </summary>
        MinHeight,
        /// <summary>
        /// The minimum width to which the dialog can be resized, in pixels.
        /// </summary>
        MinWidth,
        /// <summary>
        /// If set to true, the dialog will have modal behavior; other items on the page will be disabled (i.e. cannot be interacted with). Modal dialogs create an overlay below the dialog but above other page elements.
        /// </summary>
        Modal,
        /// <summary>
        /// Specifies where the dialog should be displayed. Possible values: 1) a single string representing position within viewport: 'center', 'left', 'right', 'top', 'bottom'. 2) an array containing an x,y coordinate pair in pixel offset from left, top corner of viewport (e.g. [350,100]) 3) an array containing x,y position string values (e.g. ['right','top'] for top right corner).
        /// </summary>
        Position,
        /// <summary>
        /// If set to true, the dialog will be resizable.
        /// </summary>
        Resizable,
        /// <summary>
        /// The effect to be used when the dialog is opened.
        /// </summary>
        Show,
        /// <summary>
        /// Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.
        /// </summary>
        Stack,
        /// <summary>
        /// Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.
        /// </summary>
        Title,
        /// <summary>
        /// The width of the dialog, in pixels.
        /// </summary>
        Width,
        /// <summary>
        /// The starting z-index for the dialog.
        /// </summary>
        ZIndex,
    }
}
