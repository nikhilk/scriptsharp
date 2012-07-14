// TabsObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// A single content area with multiple panels, each associated with a header in a list
    /// </summary>
    /// <remarks>
    /// <para>Tabs are generally used to break content into multiple sections that can be swapped to save space, much like an accordion.</para><para>By default a tab widget will swap between tabbed sections on click, but the events can be changed to onHover through an option. Tab content can be loaded via Ajax by setting an href on a tab.</para><para>This widget requires some functional CSS, otherwise it won't work. If you build a custom theme, use the widget's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class TabsObject : WidgetObject {

        private TabsObject() {
        }

        [ScriptName("tabs")]
        public TabsObject Tabs() {
            return null;
        }

        [ScriptName("tabs")]
        public TabsObject Tabs(TabsOptions options) {
            return null;
        }

        [ScriptName("tabs")]
        public object Tabs(TabsMethod method, params object[] options) {
            return null;
        }

        /// <summary>
        /// Terminate all running tab ajax requests and animations.
        /// </summary>
        public void Abort() {
        }


        /// <summary>
        /// Add a new tab. The second argument is either a URL consisting of a fragment identifier only to create an in-page tab or a full url (relative or absolute, no cross-domain support) to turn the new tab into an Ajax (remote) tab. The third is the zero-based position where to insert the new tab. Optional, by default a new tab is appended at the end.
        /// </summary>
        public void Add(string url, string label, object index) {
        }


        /// <summary>
        /// Disable a tab. The selected tab cannot be disabled. To disable more than one tab at once use: <code>$('#example').tabs("option","disabled", [1, 2, 3]);</code><para>The argument is the zero-based index of the tab to be disabled. Instead of an index, the href of the tab may be passed.</para>
        /// </summary>
        public void Disable(object index) {
        }


        /// <summary>
        /// Enable a disabled tab. To enable more than one tab at once reset the disabled property like: <code>$('#example').tabs("option","disabled",[]);</code>.<para>The argument is the zero-based index of the tab to be enabled. Instead of an index, the href of the tab may be passed.</para>
        /// </summary>
        public void Enable(object index) {
        }


        /// <summary>
        /// Retrieve the number of tabs of the first matched tab pane.
        /// </summary>
        public new void Length() {
        }


        /// <summary>
        /// Load the panel content of a remote tab (specified by index)
        /// </summary>
        public void Load(object index) {
        }


        /// <summary>
        /// Remove a tab. The second argument is the zero-based index of the tab to be removed. Instead of an index, the href of the tab may be passed.
        /// </summary>
        public void Remove(object index) {
        }


        /// <summary>
        /// Set up an automatic rotation through tabs of a tab pane. The second argument is an amount of time in milliseconds until the next tab in the cycle gets activated. Use 0 or null to stop the rotation. The third controls whether or not to continue the rotation after a tab has been selected by a user. Default: false.
        /// </summary>
        public void Rotate(int ms, bool continuing) {
        }


        /// <summary>
        /// Select a tab, as if it were clicked. The second argument is the zero-based index of the tab to be selected or the id selector of the panel the tab is associated with (the tab's href fragment identifier, e.g. hash, points to the panel's id).
        /// </summary>
        public void Select(object index) {
        }


        /// <summary>
        /// Change the url from which an Ajax (remote) tab will be loaded. The specified URL will be used for subsequent loads. Note that you can not only change the URL for an existing remote tab with this method, but also turn an in-page tab into a remote tab. The second argument is the zero-based index of the tab of which its URL is to be updated. The third is a URL the content of the tab is loaded from.
        /// </summary>
        public void Url(object index, string url) {
        }

    }
}
