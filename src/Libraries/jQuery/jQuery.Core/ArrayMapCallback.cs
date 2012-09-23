// ArrayMapCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each item in an array being mapped.
    /// </summary>
    /// <param name="item">The item within the array.</param>
    /// <param name="index">The index of the item.</param>
    /// <returns>The value that the item was mapped to.</returns>
    [IgnoreNamespace]
    [ScriptImport]
    public delegate object ArrayMapCallback(object item, int index);
}
