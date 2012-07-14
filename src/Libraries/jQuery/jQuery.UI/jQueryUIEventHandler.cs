// jQueryUIEventHandler.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Handles a widget event.
    /// </summary>
    /// <typeparam name="T">The type of the widget event object.</typeparam>
    /// <param name="e">The associated jQuery event object.</param>
    /// <param name="uiEvent">The widget event information.</param>
    [Imported]
    [IgnoreNamespace]
    public delegate void jQueryUIEventHandler<T>(jQueryEvent e, T uiEvent);
}
