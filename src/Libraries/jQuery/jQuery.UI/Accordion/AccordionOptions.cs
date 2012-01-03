// AccordionOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Accordion
// Auto-generated code!
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class AccordionOptions
    {
        public AccordionOptions() { }
        public AccordionOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when accordion is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered every time the accordion changes. If the accordion is animated, the event will be triggered upon completion of the animation; otherwise, it is triggered immediately.
        /// </summary>
        [IntrinsicProperty]
        public AccordionEventHandler Change { get { return null; } set { } }

        /// <summary>
        /// This event is triggered every time the accordion starts to change.
        /// </summary>
        [IntrinsicProperty]
        public AccordionEventHandler Changestart { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Disables (true) or enables (false) the accordion. Can be set when initialising (first creating) the accordion.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled { get { return false; } set { } }

        /// <summary>
        /// Selector for the active element. Set to false to display none at start. Needs <code>collapsible: true</code>.
        /// </summary>
        [IntrinsicProperty]
        public object Active { get { return null; } set { } }

        /// <summary>
        /// Choose your favorite animation, or disable them (set to false). In addition to the default, 'bounceslide' and all defined easing methods are supported ('bounceslide' requires UI Effects Core).
        /// </summary>
        [IntrinsicProperty]
        public object Animated { get { return null; } set { } }

        /// <summary>
        /// If set, the highest content part is used as height reference for all other parts. Provides more consistent animations.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoHeight { get { return false; } set { } }

        /// <summary>
        /// If set, clears height and overflow styles after finishing animations. This enables accordions to work with dynamic content. Won't work together with autoHeight.
        /// </summary>
        [IntrinsicProperty]
        public bool ClearStyle { get { return false; } set { } }

        /// <summary>
        /// Whether all the sections can be closed at once. Allows collapsing the active section by the triggering event (click is the default).
        /// </summary>
        [IntrinsicProperty]
        public bool Collapsible { get { return false; } set { } }

        /// <summary>
        /// The event on which to trigger the accordion.
        /// </summary>
        [IntrinsicProperty]
        public string Event { get { return null; } set { } }

        /// <summary>
        /// If set, the accordion completely fills the height of the parent element. Overrides autoheight.
        /// </summary>
        [IntrinsicProperty]
        public bool FillSpace { get { return false; } set { } }

        /// <summary>
        /// Selector for the header element.
        /// </summary>
        [IntrinsicProperty]
        public object Header { get { return null; } set { } }

        /// <summary>
        /// Icons to use for headers. Icons may be specified for 'header' and 'headerSelected', and we recommend using the icons native to the jQuery UI CSS Framework manipulated by [http://www.themeroller.com jQuery UI ThemeRoller]. Set to false to have no icons displayed.
        /// </summary>
        [IntrinsicProperty]
        public AccordionIcons Icons { get { return null; } set { } }

        /// <summary>
        /// If set, looks for the anchor that matches location.href and activates it. Great for href-based state-saving. Use navigationFilter to implement your own matcher.
        /// </summary>
        [IntrinsicProperty]
        public bool Navigation { get { return false; } set { } }

        /// <summary>
        /// Overwrite the default location.href-matching with your own matcher.
        /// </summary>
        [IntrinsicProperty]
        public Action NavigationFilter { get { return null; } set { } }

        #endregion
    }
}
