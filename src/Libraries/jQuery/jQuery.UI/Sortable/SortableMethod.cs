// SortableMethod.cs
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
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SortableMethod
    {
        /// <summary>
        /// Remove the sortable functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the sortable.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the sortable.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple sortable options at once by providing an options object.Get or set any sortable option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-sortable element.
        /// </summary>
        Widget,
        /// <summary>
        /// Serializes the sortable's item id's into a form/ajax submittable string. Calling this method produces a hash that can be appended to any url to easily submit a new item order back to the server.
        /// </summary>
        Serialize,
        /// <summary>
        /// Serializes the sortable's item id's into an array of string.
        /// </summary>
        ToArray,
        /// <summary>
        /// Refresh the sortable items. Custom trigger the reloading of all sortable items, causing new items to be recognized.
        /// </summary>
        Refresh,
        /// <summary>
        /// Refresh the cached positions of the sortables' items. Calling this method refreshes the cached item positions of all sortables. This is usually done automatically by the script and slows down performance. Use wisely.
        /// </summary>
        RefreshPositions,
        /// <summary>
        /// Cancels a change in the current sortable and reverts it back to how it was before the current sort started. Useful in the stop and receive callback functions.
        /// </summary>
        Cancel,
    }
}
