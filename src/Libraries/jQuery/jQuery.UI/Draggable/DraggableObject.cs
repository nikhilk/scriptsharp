// DraggableObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Draggable
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
    /// The jQuery UI Draggable plugin makes selected elements draggable by mouse.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class DraggableObject : jQueryObject
    {
        [ScriptName("draggable")]
        public extern DraggableObject Draggable();

        [ScriptName("draggable")]
        public extern DraggableObject Draggable(DraggableOptions options);

        [ScriptName("draggable")]
        public extern object Draggable(DraggableMethod method, params object[] options);
    }
}
