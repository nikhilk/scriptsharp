// AutocompleteMethod.cs
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
    [NamedValues]
    public enum AutocompleteMethod
    {
        /// <summary>
        /// Triggers a search event, which, when data is available, then will display the suggestions; can be used by a selectbox-like button to open the suggestions when clicked. If no value argument is specified, the current input's value is used. Can be called with an empty string and minLength: 0 to display all items.
        /// </summary>
        Search,
        /// <summary>
        /// Close the Autocomplete menu. Useful in combination with the search method, to close the open menu.
        /// </summary>
        Close,
    }
}
