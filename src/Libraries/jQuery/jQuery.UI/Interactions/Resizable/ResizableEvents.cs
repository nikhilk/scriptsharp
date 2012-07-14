// ResizableEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Events raised by Resizable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum ResizableEvents {

        /// <summary>
        /// This event is triggered when the resizable is created.
        /// </summary>
        Create,

        /// <summary>
        /// This event is triggered during the resize, on the drag of the resize handler.
        /// </summary>
        Resize,

        /// <summary>
        /// This event is triggered at the start of a resize operation.
        /// </summary>
        Start,

        /// <summary>
        /// This event is triggered at the end of a resize operation.
        /// </summary>
        Stop
    }
}
