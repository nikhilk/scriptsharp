// TabsMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Operations supported by Tabs.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum TabsMethod {

        /// <summary>
        /// Terminate all running tab ajax requests and animations.
        /// </summary>
        Abort,

        /// <summary>
        /// Add a new tab. The second argument is either a URL consisting of a fragment identifier only to create an in-page tab or a full url (relative or absolute, no cross-domain support) to turn the new tab into an Ajax (remote) tab. The third is the zero-based position where to insert the new tab. Optional, by default a new tab is appended at the end.
        /// </summary>
        Add,

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        /// <summary>
        /// Retrieve the number of tabs of the first matched tab pane.
        /// </summary>
        Length,

        /// <summary>
        /// Load the panel content of a remote tab (specified by index)
        /// </summary>
        Load,

        Option,

        /// <summary>
        /// Remove a tab. The second argument is the zero-based index of the tab to be removed. Instead of an index, the href of the tab may be passed.
        /// </summary>
        Remove,

        /// <summary>
        /// Set up an automatic rotation through tabs of a tab pane. The second argument is an amount of time in milliseconds until the next tab in the cycle gets activated. Use 0 or null to stop the rotation. The third controls whether or not to continue the rotation after a tab has been selected by a user. Default: false.
        /// </summary>
        Rotate,

        /// <summary>
        /// Select a tab, as if it were clicked. The second argument is the zero-based index of the tab to be selected or the id selector of the panel the tab is associated with (the tab's href fragment identifier, e.g. hash, points to the panel's id).
        /// </summary>
        Select,

        /// <summary>
        /// Change the url from which an Ajax (remote) tab will be loaded. The specified URL will be used for subsequent loads. Note that you can not only change the URL for an existing remote tab with this method, but also turn an in-page tab into a remote tab. The second argument is the zero-based index of the tab of which its URL is to be updated. The third is a URL the content of the tab is loaded from.
        /// </summary>
        Url,

        Widget
    }
}
