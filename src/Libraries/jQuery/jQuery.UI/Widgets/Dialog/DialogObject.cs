// DialogObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Open content in an interactive overlay
    /// </summary>
    /// <remarks>
    /// <para>A dialog is a floating window that contains a title bar and a content area. The dialog window can be moved, resized and closed with the 'x' icon by default.</para><para>If the content length exceeds the maximum height, a scrollbar will automatically appear.</para><para>A bottom button bar and semi-transparent modal overlay layer are common options that can be added.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class DialogObject : WidgetObject {

        private DialogObject() {
        }

        [ScriptName("dialog")]
        public DialogObject Dialog() {
            return null;
        }

        [ScriptName("dialog")]
        public DialogObject Dialog(DialogOptions options) {
            return null;
        }

        [ScriptName("dialog")]
        public object Dialog(DialogMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Close the dialog.
        /// </summary>
        public void Close() {
        }


        /// <summary>
        /// Returns true if the dialog is currently open.
        /// </summary>
        public void IsOpen() {
        }


        /// <summary>
        /// Move the dialog to the top of the dialogs stack.
        /// </summary>
        public void MoveToTop() {
        }


        /// <summary>
        /// Open the dialog.
        /// </summary>
        public void Open() {
        }

    }
}
