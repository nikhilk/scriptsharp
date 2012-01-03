// TabsOptions.cs
// Script#/Libraries/jQuery/jQuery.UI/Tabs
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
    public sealed class TabsOptions
    {
        public TabsOptions() { }
        public TabsOptions(params object[] nameValuePairs) { }

        #region Events

        /// <summary>
        /// This event is triggered when tabs is created.
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler Create { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when clicking a tab.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Select { get { return null; } set { } }

        /// <summary>
        /// This event is triggered after the content of a remote tab has been loaded.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Load { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a tab is shown.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Show { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a tab is added.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Add { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a tab is removed.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Remove { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a tab is enabled.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Enable { get { return null; } set { } }

        /// <summary>
        /// This event is triggered when a tab is disabled.
        /// </summary>
        [IntrinsicProperty]
        public TabsEventHandler Disable { get { return null; } set { } }

        #endregion

        #region Options

        /// <summary>
        /// Additional Ajax options to consider when loading tab content (see $.ajax).
        /// </summary>
        [IntrinsicProperty]
        public object AjaxOptions { get { return null; } set { } }

        /// <summary>
        /// Whether or not to cache remote tabs content, e.g. load only once or with every click. Cached content is being lazy loaded, e.g once and only once for the first click. Note that to prevent the actual Ajax requests from being cached by the browser you need to provide an extra cache: false flag to ajaxOptions.
        /// </summary>
        [IntrinsicProperty]
        public bool Cache { get { return false; } set { } }

        /// <summary>
        /// Set to true to allow an already selected tab to become unselected again upon reselection.
        /// </summary>
        [IntrinsicProperty]
        public bool Collapsible { get { return false; } set { } }

        /// <summary>
        /// Store the latest selected tab in a cookie. The cookie is then used to determine the initially selected tab if the ''selected'' option is not defined. Requires [http://plugins.jquery.com/project/cookie cookie plugin], which can also be found in the development-bundle>external folder from the download builder. The object needs to have key/value pairs of the form the cookie plugin expects as options. Available options (example): &#123; expires: 7, path: '/', domain: 'jquery.com', secure: true &#125;. Since jQuery UI 1.7 it is also possible to define the cookie name being used via ''name'' property.
        /// </summary>
        [IntrinsicProperty]
        public object Cookie { get { return null; } set { } }

        /// <summary>
        /// deprecated in jQuery UI 1.7, use collapsible.
        /// </summary>
        [IntrinsicProperty]
        public bool Deselectable { get { return false; } set { } }

        /// <summary>
        /// An array containing the position of the tabs (zero-based index) that should be disabled on initialization.
        /// </summary>
        [IntrinsicProperty]
        public Array Disabled { get { return null; } set { } }

        /// <summary>
        /// The type of event to be used for selecting a tab.
        /// </summary>
        [IntrinsicProperty]
        public string Event { get { return null; } set { } }

        /// <summary>
        /// Enable animations for hiding and showing tab panels. The duration option can be a string representing one of the three predefined speeds ("slow", "normal", "fast") or the duration in milliseconds to run an animation (default is "normal").
        /// </summary>
        [IntrinsicProperty]
        public object Fx { get { return null; } set { } }

        /// <summary>
        /// If the remote tab, its anchor element that is, has no title attribute to generate an id from, an id/fragment identifier is created from this prefix and a unique id returned by $.data(el), for example "ui-tabs-54".
        /// </summary>
        [IntrinsicProperty]
        public string IdPrefix { get { return null; } set { } }

        /// <summary>
        /// HTML template from which a new tab panel is created in case of adding a tab with the add method or when creating a panel for a remote tab on the fly.
        /// </summary>
        [IntrinsicProperty]
        public string PanelTemplate { get { return null; } set { } }

        /// <summary>
        /// Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.
        /// </summary>
        [IntrinsicProperty]
        public int Selected { get { return 0; } set { } }

        /// <summary>
        /// The HTML content of this string is shown in a tab title while remote content is loading. Pass in empty string to deactivate that behavior. An span element must be present in the A tag of the title, for the spinner content to be visible.
        /// </summary>
        [IntrinsicProperty]
        public string Spinner { get { return null; } set { } }

        /// <summary>
        /// HTML template from which a new tab is created and added. The placeholders #&#123;href&#125; and #&#123;label&#125; are replaced with the url and tab label that are passed as arguments to the add method.
        /// </summary>
        [IntrinsicProperty]
        public string TabTemplate { get { return null; } set { } }

        #endregion
    }
}
