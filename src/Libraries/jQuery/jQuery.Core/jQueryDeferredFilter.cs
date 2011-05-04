// jQueryDeferredFilter.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;

namespace jQueryApi {

    /// <summary>
    /// A callback that can filter a deferred object's resolved/rejected value.
    /// </summary>
    /// <param name="value">The value to be filtered.</param>
    public delegate object jQueryDeferredFilter(object value);

    // TODO: Variant
    // public delegate TTargetData jQueryDeferredFilter<TTargetData, TSourceData>(TSourceData value);
}
