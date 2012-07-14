// SlideOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options for use with Slide.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SlideOption {

        /// <summary>
        /// A callback function, executed when the effect completes
        /// </summary>
        Complete,

        /// <summary>
        /// The direction of the effect. Can be "left", "right", "up", "down".
        /// </summary>
        Direction,

        /// <summary>
        /// The distance of the effect. Is set to either the height or width of the elemenet depending on the direction option. Can be set to any integer less than the width/height of the element.
        /// </summary>
        Distance,

        /// <summary>
        /// The number of ms the animation will run for
        /// </summary>
        Duration,

        /// <summary>
        /// The easing function to use
        /// </summary>
        Easing,

        /// <summary>
        /// The mode of the effect. Can be "show" or "hide"
        /// </summary>
        Mode
    }
}
