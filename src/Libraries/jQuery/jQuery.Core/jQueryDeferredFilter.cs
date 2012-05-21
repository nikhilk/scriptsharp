// jQueryDeferredFilter.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace jQueryApi {

    /// <summary>
    /// A callback that can filter a deferred object's resolved/rejected value.
    /// </summary>
    /// <param name="value">The value to be filtered.</param>
    public delegate object jQueryDeferredFilter(object value);

    /// <summary>
    /// A callback that can filter a deferred object's resolved/rejected value.
    /// </summary>
    /// <param name="value">The value to be filtered.</param>
    public delegate TTargetData jQueryDeferredFilter<TTargetData>(object value);

    /// <summary>
    /// A callback that can filter a deferred object's resolved/rejected value.
    /// </summary>
    /// <typeparam name="TTargetData">The type of target data.</typeparam>
    /// <typeparam name="TSourceData">The type of source data.</typeparam>
    /// <param name="value">The source value to be filtered.</param>
    /// <returns>The target value.</returns>
    public delegate TTargetData jQueryDeferredFilter<TTargetData, TSourceData>(TSourceData value);
}
