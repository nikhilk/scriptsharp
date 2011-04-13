// jQueryEventHandler.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Handles a jQuery event.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public delegate void jQueryEventHandler(jQueryEvent e);
}
