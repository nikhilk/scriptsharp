// ArrayIterationCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each item in an array being iterated.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <param name="value">The item within the array.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void ArrayIterationCallback(int index, object value);

    /// <summary>
    /// A callback to be invoked for each item in an array being iterated.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <param name="value">The item within the array.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void ArrayIterationCallback<T>(int index, T value);

    /// <summary>
    /// A callback to be invoked for each item in an array being iterated.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <param name="value">The item within the array.</param>
    /// <returns>false if the iteration is to be stopped; true otherwise.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ArrayInterruptableIterationCallback(int index, object value);

    /// <summary>
    /// A callback to be invoked for each item in an array being iterated.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <param name="value">The item within the array.</param>
    /// <returns>false if the iteration is to be stopped; true otherwise.</returns>
    [IgnoreNamespace]
    [Imported]
    public delegate bool ArrayInterruptableIterationCallback<T>(int index, T value);
}
