// AutocompleteOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Autocomplete
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class AutocompleteOptions
    {
        public AutocompleteOptions() { }
        public AutocompleteOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when autocomplete is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// Before a request (source-option) is started, after minLength and delay are met. Can be canceled (return false), then no request will be started and no items suggested.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Search { get { return null; } set { } }

        /// <summary>
        /// Triggered when the suggestion menu is opened.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Open { get { return null; } set { } }

        /// <summary>
        /// Before focus is moved to an item (not selecting), ui.item refers to the focused item. The default action of focus is to replace the text field's value with the value of the focused item, though only if the focus event was triggered by a keyboard interaction. Canceling this event prevents the value from being updated, but does not prevent the menu item from being focused.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Focus { get { return null; } set { } }

        /// <summary>
        /// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Select { get { return null; } set { } }

        /// <summary>
        /// When the list is hidden - doesn't have to occur together with a change.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Close { get { return null; } set { } }

        /// <summary>
        /// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
        /// </summary>
        [IntrinsicProperty]
        public AutocompleteEventHandler Change { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Which element the menu should be appended to.
        /// </summary>
        [IntrinsicProperty]
        public string AppendTo { get { return null; } set { } }

        /// <summary>
        /// If set to true the first item will be automatically focused.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoFocus { get { return false; } set { } }

        /// <summary>
        /// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
        /// </summary>
        [IntrinsicProperty]
        public int Delay { get { return 0; } set { } }

        /// <summary>
        /// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
        /// </summary>
        [IntrinsicProperty]
        public int MinLength { get { return 0; } set { } }

        /// <summary>
        /// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the [http://docs.jquery.com/UI/Position jQuery UI Position] utility for more details about the various options.
        /// </summary>
        [IntrinsicProperty]
        public object Position { get { return null; } set { } }

        /// <summary>
        /// Defines the data to use, must be specified. See Overview section for more details, and look at the various demos.
        /// </summary>
        [IntrinsicProperty]
        public object Source { get { return null; } set { } }

        #endregion
    }
}
