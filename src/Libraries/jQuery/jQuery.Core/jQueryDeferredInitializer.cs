// jQueryDeferredInitializer.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
