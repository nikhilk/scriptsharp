// JsonStringifyCallback.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Serialization {

    /// <summary>
    /// A function that filters and serializes objects being serialized into JSON text.
    /// If the callback returns undefined, the member is not serialized. Otherwise the new
    /// value returned from the callback is serialized instead.
    /// </summary>
    /// <param name="name">The name of the member.</param>
    /// <param name="value">The value of the member.</param>
    /// <returns>The value to be serialized.</returns>
    [Imported]
    [IgnoreNamespace]
    public delegate object JsonStringifyCallback(string name, object value);
}
