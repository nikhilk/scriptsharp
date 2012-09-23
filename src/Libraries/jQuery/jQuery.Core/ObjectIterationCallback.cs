// ObjectIterationCallback.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for each property in an object being iterated.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    [IgnoreNamespace]
    [ScriptImport]
    public delegate void ObjectIterationCallback(string name, object value);

    /// <summary>
    /// A callback to be invoked for each property in an object being iterated.
    /// </summary>
    /// <param name="name">The name of the property.</param>
    /// <param name="value">The value of the property.</param>
    /// <returns>false if the iteration is to be stopped; true otherwise.</returns>
    [IgnoreNamespace]
    [ScriptImport]
    public delegate bool ObjectInterruptableIterationCallback(string name, object value);
}
