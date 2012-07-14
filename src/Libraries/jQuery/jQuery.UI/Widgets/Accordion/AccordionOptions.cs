// AccordionOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize Accordion.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class AccordionOptions {

        public AccordionOptions() {
        }

        public AccordionOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// This event is triggered every time the accordion changes. If the accordion is animated, the event will be triggered upon completion of the animation; otherwise, it is triggered immediately.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AccordionChangeEvent> Change {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered every time the accordion starts to change.
        /// </summary>
        [IntrinsicProperty]
        public jQueryUIEventHandler<AccordionChangestartEvent> Changestart {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the accordion is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// The zero-based index of the panel that is active (open). A negative value select panels going backward from the last panel.        <para>When collapsible is set to true, a false value closes the accordion, otherwise nothing happens</para>
        /// </summary>
        [IntrinsicProperty]
        public object Active {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Choose your favorite animation, or disable them (set to false). In addition to the default, 'bounceslide' and all defined easing methods are supported ('bounceslide' requires UI Effects Core).
        /// </summary>
        [IntrinsicProperty]
        public object Animated {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set, the highest content part is used as height reference for all other parts. Provides more consistent animations.
        /// </summary>
        [IntrinsicProperty]
        public bool AutoHeight {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// If set, clears height and overflow styles after finishing animations. This enables accordions to work with dynamic content. Won't work together with autoHeight.
        /// </summary>
        [IntrinsicProperty]
        public bool ClearStyle {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Whether all the sections can be closed at once. Allows collapsing the active section.
        /// </summary>
        [IntrinsicProperty]
        public bool Collapsible {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Disables the accordion if set to true.
        /// </summary>
        [IntrinsicProperty]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// The event on which to trigger the accordion.
        /// </summary>
        [IntrinsicProperty]
        public string Event {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set, the accordion completely fills the height of the parent element. Overrides autoheight.
        /// </summary>
        [IntrinsicProperty]
        public bool FillSpace {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Selector for the header element.        <para>Must be a selector that applies to the accordion container element, via .find()</para><para>The default covers both ul/li accordions, as well as flat structures like dl/dt/dd</para>
        /// </summary>
        [IntrinsicProperty]
        public string Header {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Icons to use for headers, matching an icon defined by the jQuery UI CSS Framework. Set to false to have no icons displayed.        <ul><li>header (string, default: "ui-icon-triangle-1-e")</li><li>activeHeader (string, default: "ui-icon-triangle-1-s")</li></ul>
        /// </summary>
        [IntrinsicProperty]
        public object Icons {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// If set, looks for the anchor that matches location.href and activates it. Great for href-based state-saving. Use navigationFilter to implement your own matcher.
        /// </summary>
        [IntrinsicProperty]
        public bool Navigation {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Overwrite the default location.href-matching with your own matcher.
        /// </summary>
        [IntrinsicProperty]
        public Action NavigationFilter {
            get {
                return null;
            }
            set {
            }
        }
    }
}
