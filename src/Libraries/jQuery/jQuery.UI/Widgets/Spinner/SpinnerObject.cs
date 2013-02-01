// SpinnerObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Enhance a text input for entering numeric values, with up/down buttons and arrow key handling. 
    /// </summary>
    /// <remarks>
    /// <para>Spinner, or number stepper, widget is perfect for handling all kinds of numeric input. It allow users to type a value directly or modify an existing value by spinning with the keyboard, mouse or scrollwheel. When combined with Globalize, you can even spin currencies and dates in a variety of locales.</para>
    /// </remarks>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class SpinnerObject : WidgetObject {

        private SpinnerObject() {
        }

        [ScriptName("spinner")]
        public TimePickerObject Spinner() {
            return null;
        }

        [ScriptName("spinner")]
        public TimePickerObject Spinner(SpinnerOptions options) {
            return null;
        }

        [ScriptName("spinner")]
        public object Spinner(SpinnerMethod method, params object[] options) {
            return null;
        }

    }
}
