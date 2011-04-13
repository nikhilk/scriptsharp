// jQueryXmlHttpRequest.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
    public sealed class jQueryXmlHttpRequest<TData> : IDeferred {

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
        /// Adds a callback to handle completion of the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Complete(AjaxCompletedCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is successfully completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Done(params Delegate[] doneCallbacks) {
            return null;
        }

        /// <summary>
        /// Adds a callback to handle an error completing the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Error(AjaxErrorCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request errors. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="failCallbacks">The callbacks to invoke (in order).</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Fail(params Delegate[] failCallbacks) {
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
        public jQueryXmlHttpRequest<TData> Success(AjaxCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Adds a callback to handle a successful completion of the request.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Success(AjaxRequestCallback<TData> callback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallback">The callback to invoke when the request completes successfully.</param>
        /// <param name="failCallback">The callback to invoke when the request completes with an error.</param>
        /// <returns>The current request object.</returns>
        public jQueryXmlHttpRequest<TData> Then(Delegate doneCallback, Delegate failCallback) {
            return null;
        }

        /// <summary>
        /// Add handlers to be called when the request is completed. If the
        /// request is already completed, the handlers are still invoked.
        /// </summary>
        /// <param name="doneCallbacks">The callbacks to invoke when the request completes successfully.</param>
        /// <param name="failCallbacks">The callbacks to invoke when the request completes with an error.</param>
        /// <returns>The current deferred object.</returns>
        public jQueryXmlHttpRequest<TData> Then(Delegate[] doneCallbacks, Delegate[] failCallbacks) {
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
