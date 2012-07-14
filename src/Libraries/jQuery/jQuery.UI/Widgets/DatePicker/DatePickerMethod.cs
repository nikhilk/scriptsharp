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
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DatePickerMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        /// <summary>
        /// Function
        /// </summary>
        Dialog,

        Disable,

        Enable,

        /// <summary>
        /// Returns the current date for the datepicker or null if no date has been selected.
        /// </summary>
        GetDate,

        /// <summary>
        /// Determine whether a date picker has been disabled.
        /// </summary>
        IsDisabled,

        Option,

        /// <summary>
        /// Redraw a date picker, after having made some external modifications.
        /// </summary>
        Refresh,

        /// <summary>
        /// Sets the current date for the datepicker. The new date may be a Date object or a string in the current [[UI/Datepicker#option-dateFormat|date format]] (e.g. '01/26/2009'), a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null to clear the selected date.
        /// </summary>
        SetDate,

        Widget
    }
}
