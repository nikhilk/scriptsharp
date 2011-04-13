// ArrayFilterCallback.cs
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
    /// A callback to be invoked for each item in an array being filtered.
    /// </summary>
    /// <param name="item">The item within the array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>True if the value satisfies the filter; false if it doesn't.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ArrayFilterCallback(object item, int index);
}
