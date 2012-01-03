// DatepickerMethod.cs
// Script#/Libraries/jQuery/jQuery.UI/Datepicker
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DatepickerMethod
    {
        /// <summary>
        /// Remove the datepicker functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the datepicker.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the datepicker.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple datepicker options at once by providing an options object.Get or set any datepicker option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-datepicker element.
        /// </summary>
        Widget,
        /// <summary>
        /// Open a datepicker in a "dialog" box.
        /// </summary>
        Dialog,
        /// <summary>
        /// Determine whether a date picker has been disabled.
        /// </summary>
        IsDisabled,
        /// <summary>
        /// Close a previously opened date picker.
        /// </summary>
        Hide,
        /// <summary>
        /// Call up a previously attached date picker.
        /// </summary>
        Show,
        /// <summary>
        /// Redraw a date picker, after having made some external modifications.
        /// </summary>
        Refresh,
        /// <summary>
        /// Returns the current date for the datepicker or null if no date has been selected.
        /// </summary>
        GetDate,
        /// <summary>
        /// Sets the current date for the datepicker. The new date may be a Date object or a string in the current [[UI/Datepicker#option-dateFormat|date format]] (e.g. '01/26/2009'), a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null to clear the selected date.
        /// </summary>
        SetDate,
    }
}
