// TabsOptions.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options used to initialize or customize Tabs.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class TabsOptions {

        public TabsOptions() {
        }

        public TabsOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Triggered after a new tab is added.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsAddEvent> Add {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when the tabs widget is created.
        /// </summary>
        [ScriptField]
        public jQueryEventHandler Create {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after an enabled tab has been disabled.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsDisableEvent> Disable {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after a disabled tab has been enabled.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsEnableEvent> Enable {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after a remote tab has been loaded.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsLoadEvent> Load {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after a tab has been removed.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsRemoveEvent> Remove {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// This event is triggered when clicking a tab.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsSelectEvent> Select {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// Triggered after a tab has been shown.
        /// </summary>
        [ScriptField]
        public jQueryUIEventHandler<TabsShowEvent> Show {
             get {
                return null;
             }
             set {
             }
        }

        /// <summary>
        /// The zero-based index of the panel that is active (open). A negative value select panels going backward from the last panel.<para>When collapsible is set to true, a false value closes the accordion, otherwise nothing happens</para>
        /// </summary>
        [ScriptField]
        public object Active {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Allow the active panel to be closed.
        /// </summary>
        [ScriptField]
        public bool Collapsible {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// An array containing the position of the tabs (zero-based index) that should be disabled.
        /// </summary>
        [ScriptField]
        public object Disabled {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// The type of event to be used for activating a tab. To activate on hover, use "mouseover".
        /// </summary>
        [ScriptField]
        public string Event {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Controls the height of the tabs widget and each panel. Possible values:<ul><li>auto: all panels will be set to the height of the tallest panel</li><li>fill: expand to the available height based on the tabs's parent height</li><li>content: each panel will be only as tall as its content</li></ul>
        /// </summary>
        [ScriptField]
        public string HeightStyle {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// How to hide a panel.
        /// </summary>
        [ScriptField]
        public object Hide {
            get {
                return null;
            }
            set {
            }
        }
    }
}
