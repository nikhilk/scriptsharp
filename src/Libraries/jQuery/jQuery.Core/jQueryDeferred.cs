// jQueryDeferred.cs
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
    public sealed class jQueryDeferred : IDeferred {

        private jQueryDeferred() {
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Done(params Delegate[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Fail(params Delegate[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Determines whether the deferred object has been rejected.
        /// </summary>
        /// <returns>true if it has been rejected; false otherwise.</returns>
        public bool IsRejected() {
            return false;
        }

        /// <summary>
        /// Determines whether the deferred object has been resolved.
        /// </summary>
        /// <returns>true if it has been resolved; false otherwise.</returns>
        public bool IsResolved() {
            return false;
        }

        /// <summary>
        /// Returns a deferred object that can be further composed.
        /// </summary>
        /// <returns>A deferred object.</returns>
        public IDeferred Promise() {
            return null;
        }

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Reject(params object[] args) {
            return null;
        }

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred RejectWith(object context, params object[] args) {
            return null;
        }

        /// <summary>
        /// Resolves the deferred object and call any done callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Resolve(params object[] args) {
            return null;
        }

        /// <summary>
        /// Resolves the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred ResolveWith(object context, params object[] args) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the object is resolved.</param>
        /// <param name="failCallback">The callback to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Then(Delegate doneCallback, Delegate failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Then(Delegate[] doneCallbacks, Delegate[] failCallbacks) {
            return null;
        }

        #region Implementation of IDeferred

        IDeferred IDeferred.Done(params Delegate[] doneCallbacks) {
            return null;
        }

        IDeferred IDeferred.Fail(params Delegate[] failCallbacks) {
            return null;
        }

        bool IDeferred.IsRejected() {
            return false;
        }

        bool IDeferred.IsResolved() {
            return false;
        }

        jQueryDeferred IDeferred.Reject(params object[] args) {
            return null;
        }

        IDeferred IDeferred.RejectWith(object context, params object[] args) {
            return null;
        }

        IDeferred IDeferred.Resolve(params object[] args) {
            return null;
        }

        IDeferred IDeferred.ResolveWith(object context, params object[] args) {
            return null;
        }

        jQueryDeferred IDeferred.Then(Delegate doneCallback, Delegate failCallback) {
            return null;
        }

        IDeferred IDeferred.Then(Delegate[] doneCallbacks, Delegate[] failCallbacks) {
            return null;
        }

        #endregion
    }
}
