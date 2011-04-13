// ElementFilterCallback.cs
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
    /// A callback to be invoked for each element in a jQueryObject being filtered.
    /// </summary>
    /// <param name="index">The index of the element in the matching set.</param>
    /// <returns>true if the element should be included; false otherwise.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ElementFilterCallback(int index);
}
