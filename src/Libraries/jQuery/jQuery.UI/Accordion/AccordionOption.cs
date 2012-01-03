// AccordionOption.cs
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
    public enum AccordionOption
    {
        /// <summary>
        /// Disables (true) or enables (false) the accordion. Can be set when initialising (first creating) the accordion.
        /// </summary>
        Disabled,
        /// <summary>
        /// Selector for the active element. Set to false to display none at start. Needs <code>collapsible: true</code>.
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
        /// Whether all the sections can be closed at once. Allows collapsing the active section by the triggering event (click is the default).
        /// </summary>
        Collapsible,
        /// <summary>
        /// The event on which to trigger the accordion.
        /// </summary>
        Event,
        /// <summary>
        /// If set, the accordion completely fills the height of the parent element. Overrides autoheight.
        /// </summary>
        FillSpace,
        /// <summary>
        /// Selector for the header element.
        /// </summary>
        Header,
        /// <summary>
        /// Icons to use for headers. Icons may be specified for 'header' and 'headerSelected', and we recommend using the icons native to the jQuery UI CSS Framework manipulated by [http://www.themeroller.com jQuery UI ThemeRoller]. Set to false to have no icons displayed.
        /// </summary>
        Icons,
        /// <summary>
        /// If set, looks for the anchor that matches location.href and activates it. Great for href-based state-saving. Use navigationFilter to implement your own matcher.
        /// </summary>
        Navigation,
        /// <summary>
        /// Overwrite the default location.href-matching with your own matcher.
        /// </summary>
        NavigationFilter,
    }
}
