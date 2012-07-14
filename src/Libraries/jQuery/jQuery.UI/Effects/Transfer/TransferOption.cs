// TransferOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Options for use with Transfer.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum TransferOption {

        /// <summary>
        /// Optional class name the transfer element will receive.
        /// </summary>
        ClassName,

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
        /// jQuery selector, the element to transfer to.
        /// </summary>
        To
    }
}
