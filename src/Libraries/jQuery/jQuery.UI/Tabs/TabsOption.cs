// TabsOption.cs
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
    public enum TabsOption
    {
        /// <summary>
        /// Additional Ajax options to consider when loading tab content (see $.ajax).
        /// </summary>
        AjaxOptions,
        /// <summary>
        /// Whether or not to cache remote tabs content, e.g. load only once or with every click. Cached content is being lazy loaded, e.g once and only once for the first click. Note that to prevent the actual Ajax requests from being cached by the browser you need to provide an extra cache: false flag to ajaxOptions.
        /// </summary>
        Cache,
        /// <summary>
        /// Set to true to allow an already selected tab to become unselected again upon reselection.
        /// </summary>
        Collapsible,
        /// <summary>
        /// Store the latest selected tab in a cookie. The cookie is then used to determine the initially selected tab if the ''selected'' option is not defined. Requires [http://plugins.jquery.com/project/cookie cookie plugin], which can also be found in the development-bundle>external folder from the download builder. The object needs to have key/value pairs of the form the cookie plugin expects as options. Available options (example): &#123; expires: 7, path: '/', domain: 'jquery.com', secure: true &#125;. Since jQuery UI 1.7 it is also possible to define the cookie name being used via ''name'' property.
        /// </summary>
        Cookie,
        /// <summary>
        /// deprecated in jQuery UI 1.7, use collapsible.
        /// </summary>
        Deselectable,
        /// <summary>
        /// An array containing the position of the tabs (zero-based index) that should be disabled on initialization.
        /// </summary>
        Disabled,
        /// <summary>
        /// The type of event to be used for selecting a tab.
        /// </summary>
        Event,
        /// <summary>
        /// Enable animations for hiding and showing tab panels. The duration option can be a string representing one of the three predefined speeds ("slow", "normal", "fast") or the duration in milliseconds to run an animation (default is "normal").
        /// </summary>
        Fx,
        /// <summary>
        /// If the remote tab, its anchor element that is, has no title attribute to generate an id from, an id/fragment identifier is created from this prefix and a unique id returned by $.data(el), for example "ui-tabs-54".
        /// </summary>
        IdPrefix,
        /// <summary>
        /// HTML template from which a new tab panel is created in case of adding a tab with the add method or when creating a panel for a remote tab on the fly.
        /// </summary>
        PanelTemplate,
        /// <summary>
        /// Zero-based index of the tab to be selected on initialization. To set all tabs to unselected pass -1 as value.
        /// </summary>
        Selected,
        /// <summary>
        /// The HTML content of this string is shown in a tab title while remote content is loading. Pass in empty string to deactivate that behavior. An span element must be present in the A tag of the title, for the spinner content to be visible.
        /// </summary>
        Spinner,
        /// <summary>
        /// HTML template from which a new tab is created and added. The placeholders #&#123;href&#125; and #&#123;label&#125; are replaced with the url and tab label that are passed as arguments to the add method.
        /// </summary>
        TabTemplate,
    }
}
