// DatePickerMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by DatePicker.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames = true)]
    public enum TimePickerMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Option,

        /// <summary>
        /// Redraw a time picker, after having made some external modifications.
        /// </summary>
        Refresh,

        /// <summary>
        /// Gets or sets the value as a valid time string per the HTML5 spec
        /// </summary>
        Value,

        Widget
    }
}
