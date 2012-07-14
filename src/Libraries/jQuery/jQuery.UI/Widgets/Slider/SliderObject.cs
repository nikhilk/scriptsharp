// SliderObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Drag a handle to select a numeric value
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Slider plugin makes selected elements into sliders. There are various options such as multiple handles, and ranges. The handle can be moved with the mouse or the arrow keys.</para>The start, slide, and stop callbacks receive two arguments: The original browser event and a prepared ui object, view below for a documentation of this object (if you name your second argument 'ui'):The slider widget will create handle elements with the class 'ui-slider-handle' on initialization. You can specify custom handle elements by creating and appending the elements and adding the 'ui-slider-handle' class before init. It will only create the number of handles needed to match the length of value/values. For example, if you specify 'values: [1, 5, 18]' and create one custom handle, the plugin will create the other two.<ul><li><b>ui.handle</b>: DOMElement - the current focused handle</li><li><b>ui.value</b>: Integer - the current handle's value</li></ul><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class SliderObject : WidgetObject {

        private SliderObject() {
        }

        [ScriptName("slider")]
        public SliderObject Slider() {
            return null;
        }

        [ScriptName("slider")]
        public SliderObject Slider(SliderOptions options) {
            return null;
        }

        [ScriptName("slider")]
        public object Slider(SliderMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Gets or sets the value of the slider. For single handle sliders.
        /// </summary>
        public void Value(int value) {
        }


        /// <summary>
        /// Number
        /// </summary>
        public void Values(int index, int value) {
        }

    }
}
