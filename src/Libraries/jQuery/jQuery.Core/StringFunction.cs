// StringFunction.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element in the set.</param>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate string StringFunction(int index);

    /// <summary>
    /// A callback that returns a value for the element at the specified index.
    /// </summary>
    /// <param name="index">The index of the element in the set.</param>
    /// <param name="currentValue">The current value.</param>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate string StringReplaceFunction(int index, string currentValue);
}
