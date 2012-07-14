// AutoCompleteOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options for use with AutoComplete.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AutoCompleteOption {

        /// <summary>
        /// Which element the menu should be appended to. Override this when the autocomplete is inside a <code>position:fixed</code> element. Otherwise the popup menu would still scroll with the page.
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
        /// Disables the autocomplete if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
        /// </summary>
        MinLength,

        /// <summary>
        /// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the [http://docs.jquery.com/UI/Position jQuery UI Position] utility for more details about the various options.
        /// </summary>
        Position,

        /// <summary>
        /// Defines the data to use, must be specified.<para>Independent of the variant you use, the label is always treated as text. If you want the label to be treated as html you can use [https://github.com/scottgonzalez/jquery-ui-extensions/blob/master/autocomplete/jquery.ui.autocomplete.html.js Scott González' html extension]. The demos all focus on different variations of the source-option - look for the one that matches your use case, and take a look at the code.</para>
        /// </summary>
        Source
    }
}
