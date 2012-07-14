// SortableObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Reorder elements in a list or grid using the mouse
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Sortable plugin makes selected elements sortable by dragging with the mouse.</para><para>All callbacks receive two arguments: The original browser event and a prepared ui object.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class SortableObject : WidgetObject {

        private SortableObject() {
        }

        [ScriptName("sortable")]
        public SortableObject Sortable() {
            return null;
        }

        [ScriptName("sortable")]
        public SortableObject Sortable(SortableOptions options) {
            return null;
        }

        [ScriptName("sortable")]
        public object Sortable(SortableMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Cancels a change in the current sortable and reverts it to the state prior to when the current sort was started. Useful in the stop and receive callback functions.<para>If the sortable item is not being moved from one connected sortable to another:</para><c>$(this).sortable('cancel');</c>will cancel the change.<para>If the sortable item is being moved from one connected sortable to another:</para><c>$(ui.sender).sortable('cancel');</c>will cancel the change. Useful in the 'receive' callback.
        /// </summary>
        public void Cancel() {
        }


        /// <summary>
        /// Refresh the sortable items. Custom trigger the reloading of all sortable items, causing new items to be recognized.
        /// </summary>
        public void Refresh() {
        }


        /// <summary>
        /// Refresh the cached positions of the sortables' items. Calling this method refreshes the cached item positions of all sortables. This is usually done automatically by the script and slows down performance. Use wisely.
        /// </summary>
        public void RefreshPositions() {
        }


        /// <summary>
        /// Serializes the sortable's item id's into a form/ajax submittable string. Calling this method produces a hash that can be appended to any url to easily submit a new item order back to the server.<para>It works by default by looking at the id of each item in the format 'setname_number', and it spits out a hash like "setname[]=number&amp;setname[]=number".</para><para>You can also give in a option hash as second argument to custom define how the function works. The possible options are: 'key' (replaces part1[] with whatever you want), 'attribute' (test another attribute than 'id') and 'expression' (use your own regexp).</para><para>If serialize returns an empty string, make sure the id attributes include an underscore.  They must be in the form: "set_number" For example, a 3 element list with id attributes foo_1, foo_5, foo_2 will serialize to foo[]=1&amp;foo[]=5&amp;foo[]=2. You can use an underscore, equal sign or hyphen to separate the set and number.  For example foo=1 or foo-1 or foo_1 all serialize to foo[]=1.</para>
        /// </summary>
        public void Serialize(object options) {
        }

    }
}
