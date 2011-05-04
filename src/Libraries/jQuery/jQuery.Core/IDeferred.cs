// IDeferred.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents a deferred value.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public interface IDeferred {

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or
        /// rejected.
        /// </summary>
        /// <param name="callbacks">The callbacsk to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Always(params Delegate[] callbacks);

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Done(params Delegate[] doneCallbacks);

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Fail(params Delegate[] failCallbacks);

        /// <summary>
        /// Determines whether the deferred object has been rejected.
        /// </summary>
        /// <returns>true if it has been rejected; false otherwise.</returns>
        bool IsRejected();

        /// <summary>
        /// Determines whether the deferred object has been resolved.
        /// </summary>
        /// <returns>true if it has been resolved; false otherwise.</returns>
        bool IsResolved();

        /// <summary>
        /// Filters or chains deffered objects.
        /// </summary>
        /// <param name="successFilter">The filter to invoke when the deferred object is resolved.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Pipe(jQueryDeferredFilter successFilter);

        /// <summary>
        /// Filters or chains deffered objects.
        /// </summary>
        /// <param name="successFilter">The filter to invoke when the deferred object is resolved.</param>
        /// <param name="failFilter">The filter to invoke when the deferred object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Pipe(jQueryDeferredFilter successFilter, jQueryDeferredFilter failFilter);

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Reject(params object[] args);

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred RejectWith(object context, params object[] args);

        /// <summary>
        /// Resolves the deferred object and call any done callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Resolve(params object[] args);

        /// <summary>
        /// Resolves the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred ResolveWith(object context, params object[] args);

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the object is resolved.</param>
        /// <param name="failCallback">The callback to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Then(Delegate doneCallback, Delegate failCallback);

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        IDeferred Then(Delegate[] doneCallbacks, Delegate[] failCallbacks);
    }
}
