// SliderEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by Slider.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SliderEvents {

        /// <summary>
        /// This event is triggered on slide stop, or if the value is changed programmatically (by the <code>value</code> method).  Takes arguments event and ui.  Use event.originalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
        /// </summary>
        Change,

        /// <summary>
        /// This event is triggered when the slider is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered on every mouse move during slide. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(..).slider('value', index) to get another handles' value.Return false in order to prevent a slide, based on ui.value.
        /// </summary>
        Slide,

        /// <summary>
        /// This event is triggered when the user starts sliding.
        /// </summary>
        Start,

        /// <summary>
        /// This event is triggered when the user stops sliding.
        /// </summary>
        Stop
    }
}
