// SliderMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by Slider.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SliderMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// Gets or sets the value of the slider. For single handle sliders.
        /// </summary>
        Value,

        /// <summary>
        /// Number
        /// </summary>
        Values,

        Widget
    }
}
