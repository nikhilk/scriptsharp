// AutoCompleteOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize AutoComplete.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class AutoCompleteOptions {

        public AutoCompleteOptions() {
        }

        public AutoCompleteOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AutoCompleteChangeEvent> Change {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// When the list is hidden - doesn't have to occur together with a change.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Close {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the autocomplete is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Before focus is moved to an item (not selecting), ui.item refers to the focused item. The default action of focus is to replace the text field's value with the value of the focused item, though only if the focus event was triggered by a keyboard interaction.<para>Canceling this event prevents the value from being updated, but does not prevent the menu item from being focused.</para>
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AutoCompleteFocusEvent> Focus {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered when the suggestion menu is opened or updated.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Open {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after a request (source-option) completes, before the menu is shown. Useful for local manipulation of suggestion data, where a custom source-option callback is not required.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AutoCompleteResponseEvent> Response {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Before a request (source-option) is started, after minLength and delay are met. Can be canceled, then no request will be started and no items suggested.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<jQueryObject> Search {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item.<para>Canceling this event prevents the value from being updated, but does not prevent the menu from closing.</para>
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AutoCompleteSelectEvent> Select {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Which element the menu should be appended to. Override this when the autocomplete is inside a <code>position:fixed</code> element. Otherwise the popup menu would still scroll with the page.
        /// </summary>
        [IntrinsicProperty]
        public string AppendTo {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set to true the first item will be automatically focused.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoFocus {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
        /// </summary>
        [IntrinsicProperty]
        public int Delay {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the autocomplete if set to true.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
        /// </summary>
        [IntrinsicProperty]
        public int MinLength {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the [http://docs.jquery.com/UI/Position jQuery UI Position] utility for more details about the various options.
        /// </summary>
        [IntrinsicProperty]
        public object Position {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Defines the data to use, must be specified.<para>Independent of the variant you use, the label is always treated as text. If you want the label to be treated as html you can use [https://github.com/scottgonzalez/jquery-ui-extensions/blob/master/autocomplete/jquery.ui.autocomplete.html.js Scott González' html extension]. The demos all focus on different variations of the source-option - look for the one that matches your use case, and take a look at the code.</para>
        /// </summary>
        [IntrinsicProperty]
        public object Source {
            get {
                return null;
            }
            set {
            }
        }
    }
}
