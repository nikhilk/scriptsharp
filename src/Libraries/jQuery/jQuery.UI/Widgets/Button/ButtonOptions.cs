// ButtonOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize Button.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ButtonOptions {

        public ButtonOptions() {
        }

        public ButtonOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered when the button is created.
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
        /// Disables the button if set to true.
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
        /// Icons to display, with or without text (see text option). The primary icon is displayed by default on the left of the label text, the secondary by default is on the right. Value for the primary and secondary properties must be a classname (String), eg. "ui-icon-gear". For using only one icon: icons: {primary:'ui-icon-locked'}. For using two icons: icons: {primary:'ui-icon-gear',secondary:'ui-icon-triangle-1-s'}
        /// </summary>
        [IntrinsicProperty]
        public object Icons {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Text to show on the button. When not specified (null), the element's html content is used, or its value attribute when it's an input element of type submit or reset; or the html content of the associated label element if its an input of type radio or checkbox
        /// </summary>
        [IntrinsicProperty]
        public string Label {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Whether to show any text - when set to false (display no text), icons (see icons option) must be enabled, otherwise it'll be ignored.
        /// </summary>
        [IntrinsicProperty]
        public bool Text {
            get {
                return false;
            }
            set {
            }
        }
    }
}
