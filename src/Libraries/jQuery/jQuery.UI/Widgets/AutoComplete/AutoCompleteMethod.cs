// AutoCompleteMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by AutoComplete.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AutoCompleteMethod {

        /// <summary>
        /// Close the Autocomplete menu. Useful in combination with the search method, to close the open menu.
        /// </summary>
        Close,

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// Triggers a search event, which, when data is available, then will display the suggestions; can be used by a selectbox-like button to open the suggestions when clicked. If no value argument is specified, the current input's value is used. Can be called with an empty string and minLength: 0 to display all items.
        /// </summary>
        Search,

        Widget
    }
}
