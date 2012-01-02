// SortableEventData.cs
// Script#/Libraries/jQuery/jQuery.UI/Sortable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SortableEventData 
    {
        /// <summary>
        /// The current helper element (most often a clone of the item)
        /// </summary>
        [IntrinsicProperty]
        public jQuery Helper { get { return null; } set { } }

        /// <summary>
        /// Current position of the helper
        /// </summary>
        [IntrinsicProperty]
        public jQueryPosition Position { get { return null; } set { } }

        /// <summary>
        /// Current absolute position of the helper
        /// </summary>
        [IntrinsicProperty]
        public jQueryPosition Offset { get { return null; } set { } }

        /// <summary>
        /// The current dragged element
        /// </summary>
        [IntrinsicProperty]
        public Element Item { get { return null; } set { } }

        /// <summary>
        /// The placeholder (if you defined one)
        /// </summary>
        [IntrinsicProperty]
        public object Placeholder { get { return null; } set { } }

        /// <summary>
        /// The sortable where the item comes from (only exists if you move from one connected list to another)
        /// </summary>
        [IntrinsicProperty]
        public SortableObject Sender { get { return null; } set { } } 
    }
}
