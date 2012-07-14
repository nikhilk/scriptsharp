// AccordionObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Convert a pair of headers and content panels into an accordion.
    /// </summary>
    /// <remarks>
    /// <para>Make the selected elements Accordion widgets.</para><para>The markup of your accordion container needs pairs of headers and content panels:</para><c><div id="accordion"><h3><a href="#">First header</a></h3><div>First content</div><h3><a href="#">Second header</a></h3><div>Second content</div></div></c><para>If you use a different element for the header, specify the header-option with an appropriate selector, eg. header: 'a.header'. The content element must be always next to its header.</para><para>If you have links inside a accordion panel and use a-elements as headers, add a class to them and use that as the header, eg. header: 'a.header'.</para><para>Use activate(Number) to change the active panel programmatically.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class AccordionObject : WidgetObject {

        private AccordionObject() {
        }

        [ScriptName("accordion")]
        public AccordionObject Accordion() {
            return null;
        }

        [ScriptName("accordion")]
        public AccordionObject Accordion(AccordionOptions options) {
            return null;
        }

        [ScriptName("accordion")]
        public object Accordion(AccordionMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Activate a content part of the Accordion programmatically. The index can be a zero-indexed number to match the position of the header to close or a Selector matching an element.
        /// </summary>
        public void Activate() {
        }


        /// <summary>
        /// Recompute heights of the accordion contents when using the fillSpace option and the container height changed. For example, when the container is a resizable, this method should be called by its resize-event.
        /// </summary>
        public void Resize() {
        }

    }
}
