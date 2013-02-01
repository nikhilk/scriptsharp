// DatePickerObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Select a time from a spinner element
    /// </summary>
    /// <remarks>
    /// <para>A basic time picker uses a 'masked input' which essentially breaks what looks like a single text input into multiple regions or zones that have custom formatting or constraints within each. A time picker can have up to 4 primary fields: hours, minutes, seconds and am/pm.</para>
    /// </remarks>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class TimePickerObject : WidgetObject {

        private TimePickerObject() {
        }

        [ScriptName("timepicker")]
        public TimePickerObject TimePicker() {
            return null;
        }

        [ScriptName("timepicker")]
        public TimePickerObject TimePicker(TimePickerOptions options) {
            return null;
        }

        [ScriptName("timepicker")]
        public object TimePicker(TimePickerMethod method, params object[] options) {
            return null;
        }


        /// <summary>
        /// Redraw a time picker, after having made some external modifications.
        /// </summary>
        public void Refresh() {
        }

    }
}
