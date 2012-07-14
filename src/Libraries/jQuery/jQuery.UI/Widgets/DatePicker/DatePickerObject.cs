// DatePickerObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Select a date from a popup or inline calendar
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Datepicker is a highly configurable plugin that adds datepicker functionality to your pages. You can customize the date format and language, restrict the selectable date ranges and add in buttons and other navigation options easily.</para><para>By default, the datepicker calendar opens in a small overlay onFocus and closes automatically onBlur or when a date is selected. For an inline calendar, simply attach the datepicker to a div or span.</para><para>You can use keyboard shortcuts to drive the datepicker:</para><ul><li>page up/down - previous/next month</li><li>ctrl+page up/down - previous/next year</li><li>ctrl+home - current month or open when closed</li><li>ctrl+left/right - previous/next day</li><li>ctrl+up/down - previous/next week</li><li>enter - accept the selected date</li><li>ctrl+end - close and erase the date</li><li>escape - close the datepicker without selection</li></ul><h3 id="utility-functions">Utility functions</h3><ul><li>$.datepicker.setDefaults( settings ) - Set settings for all datepicker instances.</li><li>$.datepicker.formatDate( format, date, settings ) - Format a date into a string value with a specified format.</li><li>$.datepicker.parseDate( format, value, settings )  - Extract a date from a string value with a specified format.</li><li>$.datepicker.iso8601Week( date ) - Determine the week of the year for a given date: 1 to 53.</li><li>$.datepicker.noWeekends - Set as beforeShowDay function to prevent selection of weekends.</li></ul><h3>Localization</h3><para>Datepicker provides support for localizing its content to cater for different languagesand date formats. Each localization is contained within its own file with thelanguage code appended to the name, e.g. <code>jquery.ui.datepicker-fr.js</code> for French.The desired localization file should be included after the main datepicker code. They add their settings to the setof available localizations and automatically apply them as defaults for all instances.</para><para>The <code>$.datepicker.regional</code> attribute holds an array of localizations,indexed by language code, with "" referring to the default (English). Each entry isan object with the following attributes: <code>closeText</code>, <code>prevText</code>,<code>nextText</code>, <code>currentText</code>, <code>monthNames</code>,<code>monthNamesShort</code>, <code>dayNames</code>, <code>dayNamesShort</code>,<code>dayNamesMin</code>, <code>weekHeader</code>, <code>dateFormat</code>,<code>firstDay</code>, <code>isRTL</code>, <code>showMonthAfterYear</code>,and <code>yearSuffix</code>.</para><para>You can restore the default localizations with:</para><code>$.datepicker.setDefaults($.datepicker.regional[""]);</code><para>And can then override an individual datepicker for a specific locale:</para><code>$(selector).datepicker($.datepicker.regional['fr']);</code><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class DatePickerObject : WidgetObject {

        private DatePickerObject() {
        }

        [ScriptName("datepicker")]
        public DatePickerObject DatePicker() {
            return null;
        }

        [ScriptName("datepicker")]
        public DatePickerObject DatePicker(DatePickerOptions options) {
            return null;
        }

        [ScriptName("datepicker")]
        public object DatePicker(DatePickerMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Function
        /// </summary>
        public void Dialog(object date, Action onSelect, object settings, object pos) {
        }


        /// <summary>
        /// Returns the current date for the datepicker or null if no date has been selected.
        /// </summary>
        public void GetDate() {
        }


        /// <summary>
        /// Determine whether a date picker has been disabled.
        /// </summary>
        public void IsDisabled() {
        }


        /// <summary>
        /// Redraw a date picker, after having made some external modifications.
        /// </summary>
        public void Refresh() {
        }


        /// <summary>
        /// Sets the current date for the datepicker. The new date may be a Date object or a string in the current [[UI/Datepicker#option-dateFormat|date format]] (e.g. '01/26/2009'), a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null to clear the selected date.
        /// </summary>
        public void SetDate(Date date) {
        }

    }
}
