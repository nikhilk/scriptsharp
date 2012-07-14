// ProgressBarObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Display status of a determinate process
    /// </summary>
    /// <remarks>
    /// <para>The progress bar is designed to simply display the current percent complete for a process. The bar is coded to be flexibly sized through CSS and will scale to fit inside it's parent container by default.</para><para>This is a determinate progress bar, meaning that it should only be used in situations where the system can accurately update the current status complete. A determinate progress bar should never fill from left to right, then loop back to empty for a single process -- if the actual percent complete status cannot be calculated, an indeterminate progress bar or spinner animation is a better way to provide user feedback.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class ProgressBarObject : WidgetObject {

        private ProgressBarObject() {
        }

        [ScriptName("progressbar")]
        public ProgressBarObject ProgressBar() {
            return null;
        }

        [ScriptName("progressbar")]
        public ProgressBarObject ProgressBar(ProgressBarOptions options) {
            return null;
        }

        [ScriptName("progressbar")]
        public object ProgressBar(ProgressBarMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// This method gets or sets the current value of the progressbar.
        /// </summary>
        public void Value(int value) {
        }

    }
}
