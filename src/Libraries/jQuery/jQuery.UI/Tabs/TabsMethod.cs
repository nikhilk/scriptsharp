// TabsMethod.cs
// Script#/Libraries/jQuery/jQuery.UI/Tabs
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
    public enum TabsMethod
    {
        /// <summary>
        /// Remove the tabs functionality completely. This will return the element back to its pre-init state.
        /// </summary>
        Destroy,
        /// <summary>
        /// Set multiple tabs options at once by providing an options object.Get or set any tabs option. If no value is specified, will act as a getter.
        /// </summary>
        Option,
        /// <summary>
        /// Returns the .ui-tabs element.
        /// </summary>
        Widget,
        /// <summary>
        /// Add a new tab. The second argument is either a URL consisting of a fragment identifier only to create an in-page tab or a full url (relative or absolute, no cross-domain support) to turn the new tab into an Ajax (remote) tab. The third is the zero-based position where to insert the new tab. Optional, by default a new tab is appended at the end.
        /// </summary>
        Add,
        /// <summary>
        /// Remove a tab. The second argument is the zero-based index of the tab to be removed.
        /// </summary>
        Remove,
        /// <summary>
        /// Enable a disabled tab.  To enable more than one tab at once reset the disabled property like: <code>$('#example').tabs("option","disabled",[]);</code>. The second argument is the zero-based index of the tab to be enabled.
        /// </summary>
        Enable,
        /// <summary>
        /// Disable a tab. The selected tab cannot be disabled. To disable more than one tab at once use: <code>$('#example').tabs("option","disabled", [1, 2, 3]);</code>  The second argument is the zero-based index of the tab to be disabled. 
        /// </summary>
        Disable,
        /// <summary>
        /// Select a tab, as if it were clicked. The second argument is the zero-based index of the tab to be selected or the id selector of the panel the tab is associated with (the tab's href fragment identifier, e.g. hash, points to the panel's id).
        /// </summary>
        Select,
        /// <summary>
        /// Reload the content of an Ajax tab programmatically. This method always loads the tab content from the remote location, even if cache is set to true. The second argument is the zero-based index of the tab to be reloaded. 
        /// </summary>
        Load,
        /// <summary>
        /// Change the url from which an Ajax (remote) tab will be loaded. The specified URL will be used for subsequent loads. Note that you can not only change the URL for an existing remote tab with this method, but also turn an in-page tab into a remote tab.  The second argument is the zero-based index of the tab of which its URL is to be updated.  The third is a URL the content of the tab is loaded from.
        /// </summary>
        Url,
        /// <summary>
        /// Retrieve the number of tabs of the first matched tab pane.
        /// </summary>
        Length,
        /// <summary>
        /// Terminate all running tab ajax requests and animations.
        /// </summary>
        Abort,
        /// <summary>
        /// Set up an automatic rotation through tabs of a tab pane.  The second argument is an amount of time in milliseconds until the next tab in the cycle gets activated. Use 0 or null to stop the rotation.  The third controls whether or not to continue the rotation after a tab has been selected by a user. Default: false.
        /// </summary>
        Rotate,
    }
}
