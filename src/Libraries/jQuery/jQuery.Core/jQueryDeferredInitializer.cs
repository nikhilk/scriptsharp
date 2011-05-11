// jQueryDeferredInitializer.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace jQueryApi {

    /// <summary>
    /// A callback that can initialize a deferred object during construction.
    /// </summary>
    /// <param name="deferred">The deferred object being created.</param>
    public delegate void jQueryDeferredInitializer(jQueryDeferred deferred);

    /// <summary>
    /// A callback that can initialize a deferred object during construction.
    /// </summary>
    /// <param name="deferred">The deferred object being created.</param>
    public delegate void jQueryDeferredInitializer<TData>(jQueryDeferred<TData> deferred);
}
