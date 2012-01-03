// SelectableOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Selectable
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SelectableOptions
    {
        public SelectableOptions() { }
        public SelectableOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when selectable is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered at the end of the select operation, on each element added to the selection.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Selected { get { return null; } set { } }

        /// <summary>
        /// This event is triggered during the select operation, on each element added to the selection.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Selecting { get { return null; } set { } }

        /// <summary>
        /// This event is triggered at the beginning of the select operation.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Start { get { return null; } set { } }

        /// <summary>
        /// This event is triggered at the end of the select operation.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Stop { get { return null; } set { } }

        /// <summary>
        /// This event is triggered at the end of the select operation, on each element removed from the selection.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Unselected { get { return null; } set { } }

        /// <summary>
        /// This event is triggered during the select operation, on each element removed from the selection.
        /// </summary>
        [IntrinsicProperty]
        public SelectableEventHandler Unselecting { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the selectable. Can be set when initialising (first creating) the selectable.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoRefresh { get { return false; } set { } }

        /// <summary>
        /// Prevents selecting if you start on elements matching the selector.
        /// </summary>
        [IntrinsicProperty]
        public string Cancel { get { return null; } set { } }

        /// <summary>
        /// Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.
        /// </summary>
        [IntrinsicProperty]
        public int Delay { get { return 0; } set { } }

        /// <summary>
        /// Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.
        /// </summary>
        [IntrinsicProperty]
        public int Distance { get { return 0; } set { } }

        /// <summary>
        /// The matching child elements will be made selectees (able to be selected).
        /// </summary>
        [IntrinsicProperty]
        public string Filter { get { return null; } set { } }

        /// <summary>
        /// Possible values: 'touch', 'fit'.
        /// </summary>
        [IntrinsicProperty]
        public string Tolerance { get { return null; } set { } }

        #endregion
    }
}
