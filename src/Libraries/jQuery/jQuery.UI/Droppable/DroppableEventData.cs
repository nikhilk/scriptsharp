// DroppableEventData.cs
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
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class DroppableEventData
    {
        /// <summary>
        /// Current draggable element, a jQuery object.
        /// </summary>
        [IntrinsicProperty]
        public jQuery Draggable { get { return null; } set { } }

        /// <summary>
        /// Current draggable helper, a jQuery object
        /// </summary>
        [IntrinsicProperty]
        public jQuery Helper { get { return null; } set { } }

        /// <summary>
        /// Current position of the draggable helper { top: , left: }
        /// </summary>
        [IntrinsicProperty]
        public jQueryPosition Position { get { return null; } set { } }

        /// <summary>
        /// Current absolute position of the draggable helper { top: , left: }
        /// </summary>
        [IntrinsicProperty]
        public jQueryPosition Offset { get { return null; } set { } }
    }
}
