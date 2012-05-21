// ObjectMapCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each item in an object being mapped.
    /// </summary>
    /// <param name="item">The item within the object.</param>
    /// <param name="key">The key of the item.</param>
    /// <returns>The value that the item was mapped to.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate object ObjectMapCallback(object item, string key);
}
