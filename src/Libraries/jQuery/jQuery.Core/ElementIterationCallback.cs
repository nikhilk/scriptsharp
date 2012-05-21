// ElementIterationCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each element in a jQueryObject being iterated.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <param name="element">The element.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void ElementIterationCallback(int index, Element element);

    /// <summary>
    /// A callback to be invoked for each element in a jQueryObject being iterated.
    /// </summary>
    /// <param name="index">The index of the element.</param>
    /// <param name="element">The element.</param>
    /// <returns>false if the iteration is to be stopped; true otherwise.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ElementInterruptibleIterationCallback(int index, Element element);
}
