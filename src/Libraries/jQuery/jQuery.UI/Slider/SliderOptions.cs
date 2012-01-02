// SliderOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Slider
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class SliderOptions
    {
        public SliderOptions() { }
        public SliderOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when slider is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when the user starts sliding.
        /// </summary>
        [IntrinsicProperty]
        public SliderEventHandler Start { get { return null; } set { } }

        /// <summary>
        /// This event is triggered on every mouse move during slide. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(..).slider('value', index) to get another handles' value.Return false in order to prevent a slide, based on ui.value.
        /// </summary>
        [IntrinsicProperty]
        public SliderEventHandler Slide { get { return null; } set { } }

        /// <summary>
        /// This event is triggered on slide stop, or if the value is changed programmatically (by the <code>value</code> method).  Takes arguments event and ui.  Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
        /// </summary>
        [IntrinsicProperty]
        public SliderEventHandler Change { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when the user stops sliding.
        /// </summary>
        [IntrinsicProperty]
        public SliderEventHandler Stop { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the slider. Can be set when initialising (first creating) the slider.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// Whether to slide handle smoothly when user click outside handle on the bar. Accepts Boolean, String or Number. Will also accept a string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </summary>
        [IntrinsicProperty]
        public object Animate { get { return null; } set { } }

        /// <summary>
        /// The maximum value of the slider.
        /// </summary>
        [IntrinsicProperty]
        public int Max { get { return 0; } set { } }

        /// <summary>
        /// The minimum value of the slider.
        /// </summary>
        [IntrinsicProperty]
        public int Min { get { return 0; } set { } }

        /// <summary>
        /// This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.
        /// </summary>
        [IntrinsicProperty]
        public SliderOrientation Orientation { get { return SliderOrientation.Horizontal; } set { } }

        /// <summary>
        /// If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.
        /// </summary>
        [IntrinsicProperty]
        public object Range { get { return null; } set { } }

        /// <summary>
        /// Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.
        /// </summary>
        [IntrinsicProperty]
        public int Step { get { return 0; } set { } }

        /// <summary>
        /// Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.
        /// </summary>
        [IntrinsicProperty]
        public int Value { get { return 0; } set { } }

        /// <summary>
        /// This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.
        /// </summary>
        [IntrinsicProperty]
        public Array Values { get { return null; } set { } }

        #endregion
    }
}
