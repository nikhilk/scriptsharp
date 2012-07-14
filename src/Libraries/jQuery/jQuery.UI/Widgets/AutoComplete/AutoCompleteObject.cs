// AutoCompleteObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Autocomplete, when added to an input field, enables users to quickly find and select from a pre-populated list of values as they type, leveraging searching and filtering.
    /// </summary>
    /// <remarks>
    /// <para>By giving an Autocomplete field focus or entering something into it, the plugin starts searching for entries that match and displays a list of values to choose from. By entering more characters, the user can filter down the list to better matches.</para><para>This can be used to enter previous selected values, for example you could use Autocomplete for entering tags, to complete an address, you could enter a city name and get the zip code, or maybe enter email addresses from an address book.</para><para>You can pull data in from a local and/or a remote source: Local is good for small data sets (like an address book with 50 entries), remote is necessary for big data sets, like a database with hundreds or millions of entries to select from.</para><para>Autocomplete can be customized to work with various data sources, by just specifying the source option.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class AutoCompleteObject : WidgetObject {

        private AutoCompleteObject() {
        }

        [ScriptName("autocomplete")]
        public AutoCompleteObject AutoComplete() {
            return null;
        }

        [ScriptName("autocomplete")]
        public AutoCompleteObject AutoComplete(AutoCompleteOptions options) {
            return null;
        }

        [ScriptName("autocomplete")]
        public object AutoComplete(AutoCompleteMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Close the Autocomplete menu. Useful in combination with the search method, to close the open menu.
        /// </summary>
        public void Close() {
        }


        /// <summary>
        /// Triggers a search event, which, when data is available, then will display the suggestions; can be used by a selectbox-like button to open the suggestions when clicked. If no value argument is specified, the current input's value is used. Can be called with an empty string and minLength: 0 to display all items.
        /// </summary>
        public void Search(string value) {
        }

    }
}
