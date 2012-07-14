// SelectableObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Use the mouse to select individual or a group of elements
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Selectable plugin allows for elements to be selected by dragging a box (sometimes called a lasso) with the mouse over the elements. Also, elements can be selected by click or drag while holding the Ctrl/Meta key, allowing for multiple (non-contiguous) selections.</para><para>This interaction requires some functional CSS, otherwise it won't work. If you build a custom theme, use the interaction's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class SelectableObject : WidgetObject {

        private SelectableObject() {
        }

        [ScriptName("selectable")]
        public SelectableObject Selectable() {
            return null;
        }

        [ScriptName("selectable")]
        public SelectableObject Selectable(SelectableOptions options) {
            return null;
        }

        [ScriptName("selectable")]
        public object Selectable(SelectableMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Refresh the position and size of each selectee element. This method can be used to manually recalculate the position and size of each selectee element. Very useful if autoRefresh is set to false.
        /// </summary>
        public void Refresh() {
        }

    }
}
