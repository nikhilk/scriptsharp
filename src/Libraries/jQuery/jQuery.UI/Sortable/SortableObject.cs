// SortableObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Sortable
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
    /// The jQuery UI Sortable plugin makes selected elements sortable by dragging with the mouse.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class SortableObject : jQueryObject
    {
        [ScriptName("sortable")]
        public extern SortableObject Sortable();

        [ScriptName("sortable")]
        public extern SortableObject Sortable(SortableOptions options);

        [ScriptName("sortable")]
        public extern object Sortable(SortableMethod method, params object[] options);
    }
}
