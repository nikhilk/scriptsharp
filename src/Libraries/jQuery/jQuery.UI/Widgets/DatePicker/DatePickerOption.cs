// DatePickerOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options for use with DatePicker.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum DatePickerOption {

        /// <summary>
        /// The jQuery selector for another field that is to be updated with the selected date from the datepicker. Use the <code>[[UI/Datepicker#option-altFormat|altFormat]]</code> setting to change the format of the date within this field. Leave as blank for no alternate field.
        /// </summary>
        AltField,

        /// <summary>
        /// The <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> to be used for the <code>[[UI/Datepicker#option-altField|altField]]</code> option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the [[UI/Datepicker/formatDate|formatDate]] function
        /// </summary>
        AltFormat,

        /// <summary>
        /// The text to display after each date field, e.g. to show the required format.
        /// </summary>
        AppendText,

        /// <summary>
        /// Set to true to automatically resize the input field to accommodate dates in the current <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code>.
        /// </summary>
        AutoSize,

        /// <summary>
        /// The URL for the popup button image. If set, <code>[[UI/Datepicker#option-buttonText|buttonText]]</code> becomes the ''alt'' value and is not directly displayed.
        /// </summary>
        ButtonImage,

        /// <summary>
        /// Set to true to place an image after the field to use as the trigger without it appearing on a button.
        /// </summary>
        ButtonImageOnly,

        /// <summary>
        /// The text to display on the trigger button. Use in conjunction with <code>[[UI/Datepicker#option-showOn|showOn]]</code> equal to 'button' or 'both'.
        /// </summary>
        ButtonText,

        /// <summary>
        /// myWeekCalc
        /// </summary>
        CalculateWeek,

        /// <summary>
        /// Allows you to change the month by selecting from a drop-down list. You can enable this feature by setting the attribute to true.
        /// </summary>
        ChangeMonth,

        /// <summary>
        /// Allows you to change the year by selecting from a drop-down list. You can enable this feature by setting the attribute to true. Use the <code>[[UI/Datepicker#option-yearRange|yearRange]]</code> option to control which years are made available for selection.
        /// </summary>
        ChangeYear,

        /// <summary>
        /// The text to display for the close link. This attribute is one of the regionalisation attributes. Use the <code>[[UI/Datepicker#option-showButtonPanel|showButtonPanel]]</code> to display this button.
        /// </summary>
        CloseText,

        /// <summary>
        /// When true entry in the input field is constrained to those characters allowed by the current <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code>.
        /// </summary>
        ConstrainInput,

        /// <summary>
        /// The text to display for the current day link. This attribute is one of the regionalisation attributes. Use the <code>[[UI/Datepicker#option-showButtonPanel|showButtonPanel]]</code> to display this button.
        /// </summary>
        CurrentText,

        /// <summary>
        /// The format for parsed and displayed dates. This attribute is one of the regionalisation attributes. For a full list of the possible formats see the <code>[[UI/Datepicker/formatDate|formatDate]]</code> function.
        /// </summary>
        DateFormat,

        /// <summary>
        /// The list of long day names, starting from Sunday, for use as requested via the <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> setting. They also appear as popup hints when hovering over the corresponding column headings. This attribute is one of the regionalisation attributes.
        /// </summary>
        DayNames,

        /// <summary>
        /// The list of minimised day names, starting from Sunday, for use as column headers within the datepicker. This attribute is one of the regionalisation attributes.
        /// </summary>
        DayNamesMin,

        /// <summary>
        /// The list of abbreviated day names, starting from Sunday, for use as requested via the <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> setting. This attribute is one of the regionalisation attributes.
        /// </summary>
        DayNamesShort,

        /// <summary>
        /// Set the date to highlight on first opening if the field is blank. Specify either an actual date via a Date object or as a string in the current <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code>, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null for today.
        /// </summary>
        DefaultDate,

        /// <summary>
        /// Disables the widget if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds ("slow", "normal", "fast").
        /// </summary>
        Duration,

        /// <summary>
        /// Set the first day of the week: Sunday is 0, Monday is 1, ... This attribute is one of the regionalisation attributes.
        /// </summary>
        FirstDay,

        /// <summary>
        /// When true the current day link moves to the currently selected date instead of today.
        /// </summary>
        GotoCurrent,

        /// <summary>
        /// Normally the previous and next links are disabled when not applicable (see <code>[[UI/Datepicker#option-minDate|minDate]]</code>/<code>[[UI/Datepicker#option-maxDate|maxDate]]</code>). You can hide them altogether by setting this attribute to true.
        /// </summary>
        HideIfNoPrevNext,

        /// <summary>
        /// True if the current language is drawn from right to left. This attribute is one of the regionalisation attributes.
        /// </summary>
        IsRTL,

        /// <summary>
        /// Set a maximum selectable date via a Date object or as a string in the current <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code>, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +1w'), or null for no limit.
        /// </summary>
        MaxDate,

        /// <summary>
        /// Set a minimum selectable date via a Date object or as a string in the current <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code>, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '-1y -1m'), or null for no limit.
        /// </summary>
        MinDate,

        /// <summary>
        /// The list of full month names, for use as requested via the <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> setting. This attribute is one of the regionalisation attributes.
        /// </summary>
        MonthNames,

        /// <summary>
        /// The list of abbreviated month names, as used in the month header on each datepicker and as requested via the <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> setting. This attribute is one of the regionalisation attributes.
        /// </summary>
        MonthNamesShort,

        /// <summary>
        /// When true the <code>[[UI/Datepicker/formatDate|formatDate]]</code> function is applied to the <code>[[UI/Datepicker#option-prevText|prevText]]</code>, <code>[[UI/Datepicker#option-nextText|nextText]]</code>, and <code>[[UI/Datepicker#option-currentText|currentText]]</code> values before display, allowing them to display the target month names for example.
        /// </summary>
        NavigationAsDateFormat,

        /// <summary>
        /// The text to display for the next month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.
        /// </summary>
        NextText,

        /// <summary>
        /// Set how many months to show at once. The value can be a straight integer, or can be a two-element array to define the number of rows and columns to display.
        /// </summary>
        NumberOfMonths,

        /// <summary>
        /// The text to display for the previous month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.
        /// </summary>
        PrevText,

        /// <summary>
        /// When true days in other months shown before or after the current month are selectable. This only applies if <code>[[UI/Datepicker#option-showOtherMonths|showOtherMonths]]</code> is also true.
        /// </summary>
        SelectOtherMonths,

        /// <summary>
        /// Set the cutoff year for determining the century for a date (used in conjunction with <code>[[UI/Datepicker#option-dateFormat|dateFormat]]</code> 'y'). If a numeric value (0-99) is provided then this value is used directly. If a string value is provided then it is converted to a number and added to the current year. Once the cutoff year is calculated, any dates entered with a year value less than or equal to it are considered to be in the current century, while those greater than it are deemed to be in the previous century.
        /// </summary>
        ShortYearCutoff,

        /// <summary>
        /// Set the name of the animation used to show/hide the datepicker. Use 'show' (the default), 'slideDown', 'fadeIn', any of the show/hide [http://docs.jquery.com/UI/Effects jQuery UI effects], or "" for no animation.
        /// </summary>
        ShowAnim,

        /// <summary>
        /// Whether to show the button panel.
        /// </summary>
        ShowButtonPanel,

        /// <summary>
        /// Specify where in a [[UI/Datepicker#option-numberOfMonths|multi-month]] display the current month shows, starting from 0 at the top/left.
        /// </summary>
        ShowCurrentAtPos,

        /// <summary>
        /// Whether to show the month after the year in the header. This attribute is one of the regionalisation attributes.
        /// </summary>
        ShowMonthAfterYear,

        /// <summary>
        /// Have the datepicker appear automatically when the field receives focus ("focus"), appear only when a button is clicked ("button"), or appear when either event taks place ("both").
        /// </summary>
        ShowOn,

        /// <summary>
        /// If using one of the jQuery UI effects for <code>[[UI/Datepicker#option-showAnim|showAnim]]</code>, you can provide additional settings for that animation via this option.
        /// </summary>
        ShowOptions,

        /// <summary>
        /// Display dates in other months (non-selectable) at the start or end of the current month. To make these days selectable use <code>[[UI/Datepicker#option-selectOtherMonths|selectOtherMonths]]</code>.
        /// </summary>
        ShowOtherMonths,

        /// <summary>
        /// When true a column is added to show the week of the year. The <code>[[UI/Datepicker#option-calculateWeek|calculateWeek]]</code> option determines how the week of the year is calculated. You may also want to change the <code>[[UI/Datepicker#option-firstDay|firstDay]]</code> option.
        /// </summary>
        ShowWeek,

        /// <summary>
        /// Set how many months to move when clicking the Previous/Next links.
        /// </summary>
        StepMonths,

        /// <summary>
        /// The text to display for the week of the year column heading. This attribute is one of the regionalisation attributes. Use <code>[[UI/Datepicker#option-showWeek|showWeek]]</code> to display this column.
        /// </summary>
        WeekHeader,

        /// <summary>
        /// Control the range of years displayed in the year drop-down: either relative to today's year (-nn:+nn), relative to the currently selected year (c-nn:c+nn), absolute (nnnn:nnnn), or combinations of these formats (nnnn:-nn). Note that this option only affects what appears in the drop-down, to restrict which dates may be selected use the <code>[[UI/Datepicker#option-minDate|minDate]]</code> and/or <code>[[UI/Datepicker#option-maxDate|maxDate]]</code> options.
        /// </summary>
        YearRange,

        /// <summary>
        /// Additional text to display after the year in the month headers. This attribute is one of the regionalisation attributes.
        /// </summary>
        YearSuffix
    }
}
