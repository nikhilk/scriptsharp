// AccordionEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by Accordion.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AccordionEvents {

        /// <summary>
        /// This event is triggered every time the accordion changes. If the accordion is animated, the event will be triggered upon completion of the animation; otherwise, it is triggered immediately.
        /// </summary>
        Change,

        /// <summary>
        /// This event is triggered every time the accordion starts to change.
        /// </summary>
        Changestart,

        /// <summary>
        /// This event is triggered when the accordion is created.
        /// </summary>
        Create
    }
}
