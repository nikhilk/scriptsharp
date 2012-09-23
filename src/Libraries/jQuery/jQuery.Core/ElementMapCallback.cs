// ElementMapCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each element in a jQueryObject being mapped.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <param name="element">The element.</param>
    /// <returns>The object that the element is mapped to.</returns>
    [IgnoreNamespace]
    [ScriptImport]
    public delegate object ElementMapCallback(int index, Element element);
}
