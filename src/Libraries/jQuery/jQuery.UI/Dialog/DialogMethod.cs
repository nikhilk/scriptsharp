// DialogMethod.cs
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
    public enum DialogMethod
    {
        /// <summary>
        /// Remove the dialog functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the dialog.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the dialog.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple dialog options at once by providing an options object.Get or set any dialog option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-dialog element.
        /// </summary>
        Widget,
        /// <summary>
        /// Close the dialog.
        /// </summary>
        Close,
        /// <summary>
        /// Returns true if the dialog is currently open.
        /// </summary>
        IsOpen,
        /// <summary>
        /// Move the dialog to the top of the dialogs stack.
        /// </summary>
        MoveToTop,
        /// <summary>
        /// Open the dialog.
        /// </summary>
        Open,
    }
}
