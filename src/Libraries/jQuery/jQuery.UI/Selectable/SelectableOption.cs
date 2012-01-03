// SelectableOption.cs
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
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SelectableOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the selectable. Can be set when initialising (first creating) the selectable.
        /// </summary>
        Disabled,
        /// <summary>
        /// This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.
        /// </summary>
        AutoRefresh,
        /// <summary>
        /// Prevents selecting if you start on elements matching the selector.
        /// </summary>
        Cancel,
        /// <summary>
        /// Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.
        /// </summary>
        Delay,
        /// <summary>
        /// Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.
        /// </summary>
        Distance,
        /// <summary>
        /// The matching child elements will be made selectees (able to be selected).
        /// </summary>
        Filter,
        /// <summary>
        /// Possible values: 'touch', 'fit'.
        /// </summary>
        Tolerance,
    }
}
