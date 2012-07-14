// TabsOption.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Widgets {

    /// <summary>
    /// Options for use with Tabs.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum TabsOption {

        /// <summary>
        /// The zero-based index of the panel that is active (open). A negative value select panels going backward from the last panel.<para>When collapsible is set to true, a false value closes the accordion, otherwise nothing happens</para>
        /// </summary>
        Active,

        /// <summary>
        /// Allow the active panel to be closed.
        /// </summary>
        Collapsible,

        /// <summary>
        /// An array containing the position of the tabs (zero-based index) that should be disabled.
        /// </summary>
        Disabled,

        /// <summary>
        /// The type of event to be used for activating a tab. To activate on hover, use "mouseover".
        /// </summary>
        Event,

        /// <summary>
        /// Controls the height of the tabs widget and each panel. Possible values:<ul><li>auto: all panels will be set to the height of the tallest panel</li><li>fill: expand to the available height based on the tabs's parent height</li><li>content: each panel will be only as tall as its content</li></ul>
        /// </summary>
        HeightStyle,

        /// <summary>
        /// How to hide a panel.
        /// </summary>
        Hide
    }
}
