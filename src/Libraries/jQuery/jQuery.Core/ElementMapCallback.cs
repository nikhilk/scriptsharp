// ElementMapCallback.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
    [Imported]
    public delegate object ElementMapCallback(int index, Element element);
}
