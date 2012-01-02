// SliderMethod.cs
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
    public enum SliderMethod
    {
        /// <summary>
        /// Remove the slider functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the slider.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the slider.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple slider options at once by providing an options object. Get or set any slider option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-slider element.
        /// </summary>
        Widget,
        /// <summary>
        /// Gets or sets the value of the slider. For single handle sliders.
        /// </summary>
        Value,
        /// <summary>
        /// Gets or sets the values of the slider. For multiple handle or range sliders.
        /// </summary>
        Values,
    }
}
