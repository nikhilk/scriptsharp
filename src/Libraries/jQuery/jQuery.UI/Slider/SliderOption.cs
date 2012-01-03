// SliderOption.cs
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
    [NamedValues]
    public enum SliderOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the slider. Can be set when initialising (first creating) the slider.
        /// </summary>
        Disabled,
        /// <summary>
        /// Whether to slide handle smoothly when user click outside handle on the bar. Accepts Boolean, String or Number. Will also accept a string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
        /// </summary>
        Animate,
        /// <summary>
        /// The maximum value of the slider.
        /// </summary>
        Max,
        /// <summary>
        /// The minimum value of the slider.
        /// </summary>
        Min,
        /// <summary>
        /// This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.
        /// </summary>
        Orientation,
        /// <summary>
        /// If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.
        /// </summary>
        Range,
        /// <summary>
        /// Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.
        /// </summary>
        Step,
        /// <summary>
        /// Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.
        /// </summary>
        Value,
        /// <summary>
        /// This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.
        /// </summary>
        Values,
    }
}
