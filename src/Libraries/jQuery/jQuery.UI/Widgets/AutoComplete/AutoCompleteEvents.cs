// AutoCompleteEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by AutoComplete.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AutoCompleteEvents {

        /// <summary>
        /// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
        /// </summary>
        Change,

        /// <summary>
        /// When the list is hidden - doesn't have to occur together with a change.
        /// </summary>
        Close,

        /// <summary>
        /// This event is triggered when the autocomplete is created.
        /// </summary>
        Create,

        /// <summary>
        /// Before focus is moved to an item (not selecting), ui.item refers to the focused item. The default action of focus is to replace the text field's value with the value of the focused item, though only if the focus event was triggered by a keyboard interaction.<para>Canceling this event prevents the value from being updated, but does not prevent the menu item from being focused.</para>
        /// </summary>
        Focus,

        /// <summary>
        /// Triggered when the suggestion menu is opened or updated.
        /// </summary>
        Open,

        /// <summary>
        /// Triggered after a request (source-option) completes, before the menu is shown. Useful for local manipulation of suggestion data, where a custom source-option callback is not required.
        /// </summary>
        Response,

        /// <summary>
        /// Before a request (source-option) is started, after minLength and delay are met. Can be canceled, then no request will be started and no items suggested.
        /// </summary>
        Search,

        /// <summary>
        /// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item.<para>Canceling this event prevents the value from being updated, but does not prevent the menu from closing.</para>
        /// </summary>
        Select
    }
}
