// SpinnerOptions.cs
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
    public sealed class SpinnerOptions {

        public SpinnerOptions() {
        }

        public SpinnerOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// The maximum allowed value.
        /// </summary>
        [ScriptField]
        public string Max {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The minimum allowed value.
        /// </summary>
        [ScriptField]
        public string Min {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods.
        /// </summary>
        [ScriptField]
        public string Step
        {
            get {
                return null;
            }
            set {
            }
        }


        /// <summary>
        /// The number of steps to take when paging via the pageUp/pageDown methods.
        /// </summary>
        [ScriptField]
        public string Page
        {
            get {
                return null;
            }
            set {
            }
        }


        /// <summary>
        /// Controls the number of steps taken when holding down a spin button.
        /// </summary>
        [ScriptField]
        public bool Incremental
        {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.
        /// </summary>
        [ScriptField]
        public object Icons
        {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Format of numbers passed to Globalize, if available.
        /// </summary>
        [ScriptField]
        public string NumberFormat
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Sets the culture to use for parsing and formatting the value. If null, the currently set culture in Globalize is used.
        /// </summary>
        [ScriptField]
        public string Culture {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the spinner if set to true.
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
    }
}
