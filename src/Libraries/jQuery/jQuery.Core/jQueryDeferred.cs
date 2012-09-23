// jQueryDeferred.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents a deferred value.
    /// </summary>
    [ScriptImport]
    [IgnoreNamespace]
    public sealed class jQueryDeferred : IDeferred {

        private jQueryDeferred() {
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or
        /// rejected.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Always(params Action[] callbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or
        /// rejected.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Always(params Callback[] callbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Done(params Action[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Done(params Callback[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Fail(params Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Fail(params Callback[] failCallbacks) {
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
        public jQueryDeferred Then(Action doneCallback, Action failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the object is resolved.</param>
        /// <param name="failCallback">The callback to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Then(Callback doneCallback, Callback failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Then(Action[] doneCallbacks, Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred Then(Callback[] doneCallbacks, Callback[] failCallbacks) {
            return null;
        }

        #region Implementation of IDeferred

        IDeferred IDeferred.Always(params Action[] callbacks) {
            return null;
        }

        IDeferred IDeferred.Always(params Callback[] callbacks) {
            return null;
        }

        IDeferred IDeferred.Done(params Action[] doneCallbacks) {
            return null;
        }

        IDeferred IDeferred.Done(params Callback[] doneCallbacks) {
            return null;
        }

        IDeferred IDeferred.Fail(params Action[] failCallbacks) {
            return null;
        }

        IDeferred IDeferred.Fail(params Callback[] failCallbacks) {
            return null;
        }

        bool IDeferred.IsRejected() {
            return false;
        }

        bool IDeferred.IsResolved() {
            return false;
        }

        IDeferred IDeferred.Pipe(jQueryDeferredFilter successFilter) {
            return null;
        }

        IDeferred IDeferred.Pipe(jQueryDeferredFilter successFilter, jQueryDeferredFilter failFilter) {
            return null;
        }

        IDeferred IDeferred.Then(Action doneCallback, Action failCallback) {
            return null;
        }

        IDeferred IDeferred.Then(Callback doneCallback, Callback failCallback) {
            return null;
        }

        IDeferred IDeferred.Then(Action[] doneCallbacks, Action[] failCallbacks) {
            return null;
        }

        IDeferred IDeferred.Then(Callback[] doneCallbacks, Callback[] failCallbacks) {
            return null;
        }

        #endregion
    }



    /// <summary>
    /// Represents a deferred value.
    /// </summary>
    [ScriptImport]
    [IgnoreNamespace]
    public sealed class jQueryDeferred<TData> : IDeferred<TData> {

        private jQueryDeferred() {
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or
        /// rejected.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Always(params Action[] callbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or
        /// rejected.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Always(params Action<TData>[] callbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Done(params Action[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Done(params Action<TData>[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Fail(params Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is rejected. If the
        /// deferred object is already resolved, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Fail(params Action<TData>[] failCallbacks) {
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
        public IDeferred<TData> Promise() {
            return null;
        }

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Reject(params TData[] args) {
            return null;
        }

        /// <summary>
        /// Rejects the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> RejectWith(object context, params TData[] args) {
            return null;
        }

        /// <summary>
        /// Resolves the deferred object and call any done callbacks with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Resolve(params TData[] args) {
            return null;
        }

        /// <summary>
        /// Resolves the deferred object and call any failure callbacks with the specified arguments
        /// using the specified context as the this parameter.
        /// </summary>
        /// <param name="context">The context in which the callback is invoked.</param>
        /// <param name="args">The arguments to pass to the callbacks.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> ResolveWith(object context, params TData[] args) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the object is resolved.</param>
        /// <param name="failCallback">The callback to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Then(Action doneCallback, Action failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the object is resolved.</param>
        /// <param name="failCallback">The callback to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Then(Action<TData> doneCallback, Action<TData> failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Then(Action[] doneCallbacks, Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the deferred object is resolved or rejected.
        /// If the object has already been resolved or rejected, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the object is resolved.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the object is rejected.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryDeferred<TData> Then(Action<TData>[] doneCallbacks, Action<TData>[] failCallbacks) {
            return null;
        }

        #region Implementation of IDeferred

        IDeferred<TData> IDeferred<TData>.Always(params Action[] callbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Always(params Action<TData>[] callbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Done(params Action[] doneCallbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Done(params Action<TData>[] doneCallbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Fail(params Action[] failCallbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Fail(params Action<TData>[] failCallbacks) {
            return null;
        }

        bool IDeferred<TData>.IsRejected() {
            return false;
        }

        bool IDeferred<TData>.IsResolved() {
            return false;
        }

        IDeferred<TTargetData> IDeferred<TData>.Pipe<TTargetData>(Func<TData, IDeferred<TTargetData>> successChain) {
            return null;
        }

        IDeferred<TTargetData> IDeferred<TData>.Pipe<TTargetData>(jQueryDeferredFilter<TTargetData, TData> successFilter) {
            return null;
        }

        IDeferred<TTargetData> IDeferred<TData>.Pipe<TTargetData>(jQueryDeferredFilter<TTargetData, TData> successFilter, jQueryDeferredFilter<TTargetData> failFilter) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Then(Action doneCallback, Action failCallback) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Then(Action<TData> doneCallback, Action<TData> failCallback) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Then(Action[] doneCallbacks, Action[] failCallbacks) {
            return null;
        }

        IDeferred<TData> IDeferred<TData>.Then(Action<TData>[] doneCallbacks, Action<TData>[] failCallbacks) {
            return null;
        }

        #endregion
    }
}
