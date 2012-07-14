// PulsateOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options for use with Pulsate.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum PulsateOption {

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
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element.</dd><dt>show</dt><dd>Shows the element.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd><dt>effect</dt><dd>Just pulsates.</dd></dl>
        /// </summary>
        Mode,

        /// <summary>
        /// The number of times the element should pulse.  An extra half pulse is added for hide/show
        /// </summary>
        Times
    }
}
