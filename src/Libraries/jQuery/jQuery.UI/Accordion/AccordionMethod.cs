// AccordionMethod.cs
// Script#/Libraries/jQuery/jQuery.UI/Accordion
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
    public enum AccordionMethod
    {
        /// <summary>
        /// Remove the accordion functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Disable the accordion.
        /// </summary>
        Disable,
        /// <summary>
        /// Enable the accordion.
        /// </summary>
        Enable,
        /// <summary>
        /// Set multiple accordion options at once by providing an options object.Get or set any accordion option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-accordion element.
        /// </summary>
        Widget,
        /// <summary>
        /// Activate a content part of the Accordion programmatically. The index can be a zero-indexed number to match the position of the header to close or a Selector matching an element. Pass <code>false</code> to close all (only possible with <code>collapsible:true</code>).
        /// </summary>
        Activate,
        /// <summary>
        /// Recompute heights of the accordion contents when using the fillSpace option and the container height changed. For example, when the container is a resizable, this method should be called by its resize-event.
        /// </summary>
        Resize,
    }
}
