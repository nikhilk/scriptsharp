// AccordionOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options for use with Accordion.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum AccordionOption {

        /// <summary>
        /// The zero-based index of the panel that is active (open). A negative value select panels going backward from the last panel.        <para>When collapsible is set to true, a false value closes the accordion, otherwise nothing happens</para>
        /// </summary>
        Active,

        /// <summary>
        /// Choose your favorite animation, or disable them (set to false). In addition to the default, 'bounceslide' and all defined easing methods are supported ('bounceslide' requires UI Effects Core).
        /// </summary>
        Animated,

        /// <summary>
        /// If set, the highest content part is used as height reference for all other parts. Provides more consistent animations.
        /// </summary>
        AutoHeight,

        /// <summary>
        /// If set, clears height and overflow styles after finishing animations. This enables accordions to work with dynamic content. Won't work together with autoHeight.
        /// </summary>
        ClearStyle,

        /// <summary>
        /// Whether all the sections can be closed at once. Allows collapsing the active section.
        /// </summary>
        Collapsible,

        /// <summary>
        /// Disables the accordion if set to true.
        /// </summary>
        Disabled,

        /// <summary>
        /// The event on which to trigger the accordion.
        /// </summary>
        Event,

        /// <summary>
        /// If set, the accordion completely fills the height of the parent element. Overrides autoheight.
        /// </summary>
        FillSpace,

        /// <summary>
        /// Selector for the header element.        <para>Must be a selector that applies to the accordion container element, via .find()</para><para>The default covers both ul/li accordions, as well as flat structures like dl/dt/dd</para>
        /// </summary>
        Header,

        /// <summary>
        /// Icons to use for headers, matching an icon defined by the jQuery UI CSS Framework. Set to false to have no icons displayed.        <ul><li>header (string, default: "ui-icon-triangle-1-e")</li><li>activeHeader (string, default: "ui-icon-triangle-1-s")</li></ul>
        /// </summary>
        Icons,

        /// <summary>
        /// If set, looks for the anchor that matches location.href and activates it. Great for href-based state-saving. Use navigationFilter to implement your own matcher.
        /// </summary>
        Navigation,

        /// <summary>
        /// Overwrite the default location.href-matching with your own matcher.
        /// </summary>
        NavigationFilter
    }
}
