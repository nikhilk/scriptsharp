// jQueryUI.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Top-level jQueryUI methods.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("$")]
    public static class jQueryUI {

        /// <summary>
        /// Exposes the widget with the specified name on the top-level jQuery API.
        /// </summary>
        /// <param name="name">The name of the widget.</param>
        /// <param name="widget">The widget object.</param>
        [ScriptName("widget.bridge")]
        public static void Bridge(string name, object widget) {
        }

        /// <summary>
        /// Create stateful jQuery plugins using the same abstraction that all jQuery UI widgets.
        /// </summary>
        /// <param name="name">The name of the widget.</param>
        /// <param name="widget">The widget object.</param>
        [ScriptName("widget")]
        public static WidgetObject CreateWidget(string name, object widget) {
            return null;
        }

        /// <summary>
        /// Create stateful jQuery plugins using the same abstraction that all jQuery UI widgets.
        /// </summary>
        /// <param name="name">The name of the widget.</param>
        /// <param name="baseWidgetType">The widget type to inherit from.</param>
        /// <param name="widget">The widget object.</param>
        [ScriptName("widget")]
        public static WidgetObject CreateWidget(string name, WidgetType baseWidgetType, object widget) {
            return null;
        }

        /// <summary>
        /// Create stateful jQuery plugins using the same abstraction that all jQuery UI widgets.
        /// </summary>
        /// <param name="name">The name of the widget.</param>
        /// <param name="baseWidgetType">The widget type to inherit from.</param>
        /// <param name="widget">The widget object.</param>
        [ScriptName("widget")]
        public static WidgetObject CreateWidget(string name, object baseWidgetType, object widget) {
            return null;
        }
    }
}
