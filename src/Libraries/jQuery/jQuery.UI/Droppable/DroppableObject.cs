// DroppableObject.cs
// Script#/Libraries/jQuery/jQuery.UI/Droppable
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
    /// The jQuery UI Droppable plugin makes selected elements droppable (meaning they accept being dropped on by draggables). You can specify which (individually) or which kind of draggables each will accept.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class DroppableObject : jQueryObject
    {
        [ScriptName("droppable")]
        public extern DroppableObject Droppable();

        [ScriptName("droppable")]
        public extern DroppableObject Droppable(DroppableOptions options);

        [ScriptName("droppable")]
        public extern object Droppable(DroppableMethod method, params object[] options);
    }
}
