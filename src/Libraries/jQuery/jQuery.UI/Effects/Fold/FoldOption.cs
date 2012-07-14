// FoldOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options for use with Fold.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum FoldOption {

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
        /// If the horizontal direction happens first when hiding. Remember, showing inverts hiding.
        /// </summary>
        HorizFirst,

        /// <summary>
        /// <para>UI Effect Mode</para><para>Possible Values: </para><dl><dt>hide</dt><dd>Hides the element.</dd><dt>show</dt><dd>Shows the element.</dd><dt>toggle</dt><dd>Will use <code>hide</code> or <code>show</code> depending on the current visibility of the element</dd></dl>
        /// </summary>
        Mode,

        /// <summary>
        /// The size of the "folded" element, can be a number representing px, or a string containing a percentage I.E. "50%"
        /// </summary>
        Size
    }
}
