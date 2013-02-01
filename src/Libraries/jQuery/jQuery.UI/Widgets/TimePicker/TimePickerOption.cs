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
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptConstants(UseNames=true)]
    public enum TimePickerOption {

        /// <summary>
        /// If the time picker should force 24 hour format - Culture might force this anyway
        /// </summary>
        Ampm,

        /// <summary>
        /// If the time picker should display/allow input of seconds 
        /// </summary>
        Seconds,

        /// <summary>
        /// If the time picker should allow empty values
        /// </summary>
        ClearEmpty,

        /// <summary>
        /// If the time picker should be disabled from input
        /// </summary>
        Disabled,

        /// <summary>
        /// Steps to increase when using PageUp Key
        /// </summary>
        Page,

        /// <summary>
        /// Set to a globalize culture to define strings for am/pm, will force 24 hour formats in cultures that don't support 12 hour formats.
        /// </summary>
        Culture
    }
}
