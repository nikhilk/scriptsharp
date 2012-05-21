// ElementFilterCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
