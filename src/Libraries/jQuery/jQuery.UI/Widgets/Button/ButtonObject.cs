// ButtonObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Themable button and buttonsets
    /// </summary>
    /// <remarks>
    /// <para>Button enhances standard form elements like button, input of type submit or reset or anchors to themable buttons with appropiate mouseover and active styles.</para><para>In addition to basic push buttons, radio buttons and checkboxes (inputs of type radio and checkbox) can be converted to buttons: Their associated label is styled to appear as the button, while the underlying input is updated on click.</para><para>In order to group radio buttons, Button also provides an additional widget-method, called buttonset. Its used by selecting a container element (which contains the radio buttons) and calling buttonset(). Buttonset will also provide visual grouping, and therefore should be used whenever you have a group of buttons. It works by selecting all descendents and applying button() to them. You can enable and disable a buttonset, which will enable and disable all contained buttons. Destroying a buttonset also calls each button's destroy method.</para><para>When using an input of type button, submit or reset, support is limited to plain text labels with no icons.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class ButtonObject : WidgetObject {

        private ButtonObject() {
        }

        [ScriptName("button")]
        public ButtonObject Button() {
            return null;
        }

        [ScriptName("button")]
        public ButtonObject Button(ButtonOptions options) {
            return null;
        }

        [ScriptName("button")]
        public object Button(ButtonMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Refreshes the visual state of the button. Useful for updating button state after the native element's checked or disabled state is changed programatically.
        /// </summary>
        public void Refresh() {
        }

    }
}
