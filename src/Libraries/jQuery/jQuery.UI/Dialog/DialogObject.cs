// DialogObject.cs
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
    /// <summary>
    /// A dialog is a floating window that contains a title bar and a content area. The dialog window can be moved, resized and closed with the 'x' icon by default.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class DialogObject : jQueryObject
    {
        [ScriptName("dialog")]
        public extern DialogObject Dialog();

        [ScriptName("dialog")]
        public extern DialogObject Dialog(DialogOptions options);

        [ScriptName("dialog")]
        public extern object Dialog(DialogMethod method, params object[] options);
    }
}
