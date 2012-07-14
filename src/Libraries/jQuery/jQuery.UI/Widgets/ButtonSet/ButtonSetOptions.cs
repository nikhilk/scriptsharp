// ButtonSetOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize ButtonSet.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ButtonSetOptions {

        public ButtonSetOptions() {
        }

        public ButtonSetOptions(params object[] nameValuePairs) {
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

        [IntrinsicProperty]
        public string Items {
            get {
                return null;
            }
            set {
            }
        }
    }
}
