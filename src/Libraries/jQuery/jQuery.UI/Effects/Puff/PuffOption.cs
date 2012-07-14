// PuffOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options for use with Puff.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum PuffOption {

        /// <summary>
        /// A callback function, executed when the effect completes
        /// </summary>
        Complete,

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
        Mode,

        /// <summary>
        /// The percentage to scale to.
        /// </summary>
        Percent
    }
}
