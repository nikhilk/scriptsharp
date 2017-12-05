// JsonParseCallback.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Serialization {

    /// <summary>
    /// A function that filters and transforms objects deserialized from JSON text.
    /// If the callback returns the same value, the member is left unmodified. If
    /// the callback returns null, the member is removed. Otherwise the new value
    /// returned from the callback is used instead.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <param name="value">The value of the member.</param>
    /// <returns>The transformed value.</returns>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    public delegate object JsonParseCallback(string name, object value);
}
