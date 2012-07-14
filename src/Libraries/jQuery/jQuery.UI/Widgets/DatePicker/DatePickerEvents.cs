// DatePickerEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by DatePicker.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DatePickerEvents {

        /// <summary>
        /// Can be a function that takes an input field and current datepicker instance and returns an options object to update the datepicker with. It is called just before the datepicker is displayed.
        /// </summary>
        BeforeShow,

        /// <summary>
        /// The function takes a date as a parameter and must return an array with [0] equal to true/false indicating whether or not this date is selectable, [1] equal to a CSS class name(s) or "" for the default presentation, and [2] an optional popup tooltip for this date. It is called for each day in the datepicker before it is displayed.
        /// </summary>
        BeforeShowDay,

        /// <summary>
        /// This event is triggered when the datepicker is created.
        /// </summary>
        Create,

        /// <summary>
        /// Allows you to define your own event when the datepicker moves to a new month and/or year. The function receives the selected year, month (1-12), and the datepicker instance as parameters. <code>this</code> refers to the associated input field.
        /// </summary>
        OnChangeMonthYear,

        /// <summary>
        /// Allows you to define your own event when the datepicker is closed, whether or not a date is selected. The function receives the selected date as text ("" if none) and the datepicker instance as parameters. <code>this</code> refers to the associated input field.
        /// </summary>
        OnClose,

        /// <summary>
        /// Allows you to define your own event when the datepicker is selected. The function receives the selected date as text and the datepicker instance as parameters. <code>this</code> refers to the associated input field.
        /// </summary>
        OnSelect
    }
}
