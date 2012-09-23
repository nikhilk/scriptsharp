// ProgressBarOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize ProgressBar.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class ProgressBarOptions {

        public ProgressBarOptions() {
        }

        public ProgressBarOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered when the value of the progressbar changes.
        /// </summary>
        [ScriptProperty]
        public jQueryUIEventHandler<jQueryObject> Change {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the value of the progressbar reaches the maximum value of 100.
        /// </summary>
        [ScriptProperty]
        public jQueryUIEventHandler<jQueryObject> Complete {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the progressbar is created.
        /// </summary>
        [ScriptProperty]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Disables the progressbar if set to true.
        /// </summary>
        [ScriptProperty]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The value of the progressbar.
        /// </summary>
        [ScriptProperty]
        public int Value {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
