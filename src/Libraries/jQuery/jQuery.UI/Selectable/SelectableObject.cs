// SelectableObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Selectable
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
    /// The jQuery UI Selectable plugin allows for elements to be selected by dragging a box (sometimes called a lasso) with the mouse over the elements. Also, elements can be selected by click or drag while holding the Ctrl/Meta key, allowing for multiple (non-contiguous) selections.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class SelectableObject : jQueryObject
    {
        [ScriptName("selectable")]
        public extern SelectableObject Selectable();

        [ScriptName("selectable")]
        public extern SelectableObject Selectable(SelectableOptions options);

        [ScriptName("selectable")]
        public extern object Selectable(SelectableMethod method, params object[] options);
    }
}
