// SelectableMethod.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Operations supported by Selectable.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [NamedValues]
    public enum SelectableMethod {

        /// <summary>
        /// The <code>destroy()</code> method cleans up all common data, events, etc. and then delegates out to <code>_destroy()</code> for custom cleanup.
        /// </summary>
        Destroy,

        Disable,

        Enable,

        Option,

        /// <summary>
        /// Refresh the position and size of each selectee element. This method can be used to manually recalculate the position and size of each selectee element. Very useful if autoRefresh is set to false.
        /// </summary>
        Refresh,

        Widget
    }
}
