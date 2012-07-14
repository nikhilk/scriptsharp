// AccordionMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by Accordion.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AccordionMethod {

        /// <summary>
        /// Activate a content part of the Accordion programmatically. The index can be a zero-indexed number to match the position of the header to close or a Selector matching an element.
        /// </summary>
        Activate,

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// Recompute heights of the accordion contents when using the fillSpace option and the container height changed. For example, when the container is a resizable, this method should be called by its resize-event.
        /// </summary>
        Resize,

        Widget
    }
}
