// SliderEvent.cs
// Script#/Libraries/jQuery/jQuery.UI/Slider
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    public static class SliderEvent
    {
        /// <summary>
        /// This event is triggered when slider is created.
        /// </summary>
        public const string Create = "slidercreate";
        /// <summary>
        /// This event is triggered when the user starts sliding.
        /// </summary>
        public const string Start = "slidestart";
        /// <summary>
        /// This event is triggered on every mouse move during slide. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(..).slider('value', index) to get another handles' value.Return false in order to prevent a slide, based on ui.value.
        /// </summary>
        public const string Slide = "slide";
        /// <summary>
        /// This event is triggered on slide stop, or if the value is changed programmatically (by the <code>value</code> method).  Takes arguments event and ui.  Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
        /// </summary>
        public const string Change = "slidechange";
        /// <summary>
        /// This event is triggered when the user stops sliding.
        /// </summary>
        public const string Stop = "slidestop";
    }
}
