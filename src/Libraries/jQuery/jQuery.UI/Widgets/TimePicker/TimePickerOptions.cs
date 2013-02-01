// DatePickerOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize TimePicker.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TimePickerOptions {

        public TimePickerOptions() {
        }

        public TimePickerOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// If the time picker should force 24 hour format - Culture might force this anyway
        /// </summary>
        [ScriptField]
        public bool Ampm {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// If the time picker should display/allow input of seconds 
        /// </summary>
        [ScriptField]
        public bool Seconds {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// If the time picker should allow empty values
        /// </summary>
        [ScriptField]
        public bool ClearEmpty
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// If the time picker should be disabled from input
        /// </summary>
        [ScriptField]
        public bool Disabled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Steps to increase when using PageUp Key
        /// </summary>
        [ScriptField]
        public int Page
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>
        /// Set to a globalize culture to define strings for am/pm, will force 24 hour formats in cultures that don't support 12 hour formats.
        /// </summary>
        [ScriptField]
        public string Culture {
            get {
                return null;
            }
            set {
            }
        }
    }
}
