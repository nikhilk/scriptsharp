// DialogEvent.cs
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
    public static class DialogEvent
    {
        /// <summary>
        /// This event is triggered when dialog is created.
        /// </summary>
        public const string Create = "dialogcreate";
        /// <summary>
        /// This event is triggered when a dialog attempts to close. If the beforeClose event handler (callback function) returns false, the close will be prevented.
        /// </summary>
        public const string BeforeClose = "dialogbeforeclose";
        /// <summary>
        /// This event is triggered when dialog is opened.
        /// </summary>
        public const string Open = "dialogopen";
        /// <summary>
        /// This event is triggered when the dialog gains focus.
        /// </summary>
        public const string Focus = "dialogfocus";
        /// <summary>
        /// This event is triggered at the beginning of the dialog being dragged.
        /// </summary>
        public const string DragStart = "dialogdragstart";
        /// <summary>
        /// This event is triggered when the dialog is dragged.
        /// </summary>
        public const string Drag = "dialogdrag";
        /// <summary>
        /// This event is triggered after the dialog has been dragged.
        /// </summary>
        public const string DragStop = "dialogdragstop";
        /// <summary>
        /// This event is triggered at the beginning of the dialog being resized.
        /// </summary>
        public const string ResizeStart = "dialogresizestart";
        /// <summary>
        /// This event is triggered when the dialog is resized. [http://www.jsfiddle.net/Jp7TM/18/ demo]
        /// </summary>
        public const string Resize = "dialogresize";
        /// <summary>
        /// This event is triggered after the dialog has been resized.
        /// </summary>
        public const string ResizeStop = "dialogresizestop";
        /// <summary>
        /// This event is triggered when the dialog is closed.
        /// </summary>
        public const string Close = "dialogclose";
    }
}
