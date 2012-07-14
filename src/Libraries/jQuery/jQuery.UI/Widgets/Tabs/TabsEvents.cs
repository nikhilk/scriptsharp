// TabsEvents.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Events raised by Tabs.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum TabsEvents {

        /// <summary>
        /// Triggered after a new tab is added.
        /// </summary>
        Add,

        /// <summary>
        /// This event is triggered when the tabs is created.
        /// </summary>
        Create,

        /// <summary>
        /// Triggered after an enabled tab has been disabled.
        /// </summary>
        Disable,

        /// <summary>
        /// Triggered after a disabled tab has been enabled.
        /// </summary>
        Enable,

        /// <summary>
        /// Triggered after a remote tab has been loaded.
        /// </summary>
        Load,

        /// <summary>
        /// Triggered after a tab has been removed.
        /// </summary>
        Remove,

        /// <summary>
        /// This event is triggered when clicking a tab.
        /// </summary>
        Select,

        /// <summary>
        /// Triggered after a tab has been shown.
        /// </summary>
        Show
    }
}
