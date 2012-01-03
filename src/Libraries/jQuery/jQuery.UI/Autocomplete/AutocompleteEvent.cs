// AutocompleteEvent.cs
// Script#/Libraries/jQuery/jQuery.UI/Autocomplete
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
    public static class AutocompleteEvent
    {
        /// <summary>
        /// This event is triggered when autocomplete is created.
        /// </summary>
        public const string Create = "autocompletecreate";
        /// <summary>
        /// Before a request (source-option) is started, after minLength and delay are met. Can be canceled (return false), then no request will be started and no items suggested.
        /// </summary>
        public const string Search = "autocompletesearch";
        /// <summary>
        /// Triggered when the suggestion menu is opened.
        /// </summary>
        public const string Open = "autocompleteopen";
        /// <summary>
        /// Before focus is moved to an item (not selecting), ui.item refers to the focused item. The default action of focus is to replace the text field's value with the value of the focused item, though only if the focus event was triggered by a keyboard interaction. Canceling this event prevents the value from being updated, but does not prevent the menu item from being focused.
        /// </summary>
        public const string Focus = "autocompletefocus";
        /// <summary>
        /// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.
        /// </summary>
        public const string Select = "autocompleteselect";
        /// <summary>
        /// When the list is hidden - doesn't have to occur together with a change.
        /// </summary>
        public const string Close = "autocompleteclose";
        /// <summary>
        /// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
        /// </summary>
        public const string Change = "autocompletechange";
    }
}
