// jQueryXmlHttpRequest.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;

namespace jQueryApi {

    /// <summary>
    /// Represents an XMLHttpRequest object as a deferred object.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public sealed class jQueryXmlHttpRequest : IDeferred {

        private jQueryXmlHttpRequest() {
        }

        /// <summary>
        /// The ready state property of the XmlHttpRequest object.
        /// </summary>
        [IntrinsicProperty]
        public ReadyState ReadyState {
            get {
                return ReadyState.Uninitialized;
            }
        }

        /// <summary>
        /// The XML document for an XML response.
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("responseXML")]
        public XmlDocument ResponseXml {
            get {
                return null;
            }
        }

        /// <summary>
        /// The text of the response.
        /// </summary>
        [IntrinsicProperty]
        public string ResponseText {
            get {
                return null;
            }
        }

        /// <summary>
        /// The status code associated with the response.
        /// </summary>
        [IntrinsicProperty]
        public int Status {
            get {
                return 0;
            }
        }

        /// <summary>
        /// The status text of the response.
        /// </summary>
        [IntrinsicProperty]
        public string StatusText {
            get {
                return null;
            }
        }

        /// <summary>
        /// Aborts the request.
        /// </summary>
        public void Abort() {
        }

        /// <summary>
        /// Add handlers to be called when the request completes or fails.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Always(params Action[] callbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request completes or fails.
        /// </summary>
        /// <param name="callbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Always(params Callback[] callbacks) {
            return null;
        }

        /// <summary>
        /// Adds a callback to handle completion of the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Complete(AjaxCompletedCallback callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is successfully completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Done(params Action[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is successfully completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Done(params Callback[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Adds a callback to handle an error completing the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Error(AjaxErrorCallback callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request errors. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Fail(params Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request errors. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Fail(params Callback[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Gets the response headers associated with the request.
        /// </summary>
        /// <returns>The response headers.</returns>
        public string GetAllResponseHeaders() {
            return null;
        }

        /// <summary>
        /// Gets a specific response header associated with the request.
        /// </summary>
        /// <param name="name">The name of the response header.</param>
        /// <returns>The response header value.</returns>
        public string GetResponseHeader(string name) {
            return null;
        }

        /// <summary>
        /// Sets the mime type on the request.
        /// </summary>
        /// <param name="type">The mime type to use.</param>
        public void OverrideMimeType(string type) {
        }

        /// <summary>
        /// Filters or chains the result of the request.
        /// </summary>
        /// <param name="successFilter">The filter to invoke when the request successfully completes.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Pipe(jQueryDeferredFilter successFilter) {
            return null;
        }

        /// <summary>
        /// Filters or chains the result of the request.
        /// </summary>
        /// <param name="successFilter">The filter to invoke when the request successfully completes.</param>
        /// <param name="failFilter">The filter to invoke when the request fails.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Pipe(jQueryDeferredFilter successFilter, jQueryDeferredFilter failFilter) {
            return null;
        }

        /// <summary>
        /// Sets a request header value.
        /// </summary>
        /// <param name="name">The name of the request header.</param>
        /// <param name="value">The value of the request header.</param>
        public void SetRequestHeader(string name, string value) {
        }

        /// <summary>
        /// Adds a callback to handle a successful completion of the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Success(AjaxCallback callback) {
            return null;
        }

        /// <summary>
        /// Adds a callback to handle a successful completion of the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Success(AjaxRequestCallback callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the request completes successfully.</param>
        /// <param name="failCallback">The callback to invoke when the request completes with an error.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Then(Action doneCallback, Action failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the request completes successfully.</param>
        /// <param name="failCallback">The callback to invoke when the request completes with an error.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest Then(Callback doneCallback, Callback failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the request completes successfully.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the request completes with an error.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryXmlHttpRequest Then(Action[] doneCallbacks, Action[] failCallbacks) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the request completes successfully.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the request completes with an error.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryXmlHttpRequest Then(Callback[] doneCallbacks, Callback[] failCallbacks) {
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
}
