// AutocompleteOption.cs
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
    public enum AutocompleteOption
    {
        /// <summary>
        /// Which element the menu should be appended to.
        /// </summary>
        AppendTo,
        /// <summary>
        /// If set to true the first item will be automatically focused.
        /// </summary>
        AutoFocus,
        /// <summary>
        /// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
        /// </summary>
        Delay,
        /// <summary>
        /// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
        /// </summary>
        MinLength,
        /// <summary>
        /// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the [http://docs.jquery.com/UI/Position jQuery UI Position] utility for more details about the various options.
        /// </summary>
        Position,
        /// <summary>
        /// Defines the data to use, must be specified. See Overview section for more details, and look at the various demos.
        /// </summary>
        Source,
    }
}
