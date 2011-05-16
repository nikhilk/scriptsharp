// EventHandler.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Delegate for handling generic events.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> object that contains the event data.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void EventHandler(object sender, EventArgs e);

    [IgnoreNamespace]
    [Imported]
    public delegate void EventHandler<TArgument>(object sender, TArgument e) where TArgument : EventArgs;
}
