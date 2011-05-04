// AjaxCallback.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// A callback to be invoked for an Ajax request.
    /// </summary>
    /// <param name="data">The result of the request.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxCallback(object data);

    /// <summary>
    /// A callback to be invoked for an Ajax request.
    /// </summary>
    /// <param name="data">The result of the request.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxCallback<TData>(TData data);

    /// <summary>
    /// A callback to be invoked for an Ajax request.
    /// </summary>
    /// <param name="data">The result of the request.</param>
    /// <param name="textStatus">The status of the request.</param>
    /// <param name="request">The request that was invoked.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxRequestCallback(object data, string textStatus, jQueryXmlHttpRequest request);

    /// <summary>
    /// A callback to be invoked for an Ajax request.
    /// </summary>
    /// <param name="data">The result of the request.</param>
    /// <param name="textStatus">The status of the request.</param>
    /// <param name="request">The request that was invoked.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxRequestCallback<TData>(TData data, string textStatus, jQueryDataHttpRequest<TData> request);

    /// <summary>
    /// A callback to be invoked for a failed Ajax request.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    /// <param name="textStatus">The status of the request.</param>
    /// <param name="error">The error or exception if any.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxErrorCallback(jQueryXmlHttpRequest request, string textStatus, Exception error);

    /// <summary>
    /// A callback to be invoked for a failed Ajax request.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    /// <param name="textStatus">The status of the request.</param>
    /// <param name="error">The error or exception if any.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxErrorCallback<TData>(jQueryDataHttpRequest<TData> request, string textStatus, Exception error);

    /// <summary>
    /// A callback to be invoked for a completed Ajax request.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    /// <param name="textStatus">The status of the request.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxCompletedCallback(jQueryXmlHttpRequest request, string textStatus);

    /// <summary>
    /// A callback to be invoked for a completed Ajax request.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    /// <param name="textStatus">The status of the request.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxCompletedCallback<TData>(jQueryDataHttpRequest<TData> request, string textStatus);

    /// <summary>
    /// A callback to be invoked for an Ajax request being sent.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxSendingCallback(jQueryXmlHttpRequest request);

    /// <summary>
    /// A callback to be invoked for an Ajax request being sent.
    /// </summary>
    /// <param name="request">The request that was invoked.</param>
    [IgnoreNamespace]
    [Imported]
    public delegate void AjaxSendingCallback<TData>(jQueryDataHttpRequest<TData> request);

    /// <summary>
    /// Creates a jQueryXmlHttpRequest object.
    /// </summary>
    /// <returns>A newly created request instance.</returns>
    public delegate jQueryXmlHttpRequest XmlHttpRequestCreator();

    /// <summary>
    /// Handles ajax events.
    /// </summary>
    /// <param name="e">The event information.</param>
    /// <param name="request">The request instance.</param>
    /// <param name="options">The Ajax options associated with the request.</param>
    public delegate void AjaxEventHandler(jQueryEvent e, jQueryXmlHttpRequest request, jQueryAjaxOptions options);

    /// <summary>
    /// Handles ajax events.
    /// </summary>
    /// <param name="e">The event information.</param>
    /// <param name="request">The request instance.</param>
    /// <param name="options">The Ajax options associated with the request.</param>
    public delegate void AjaxEventHandler<TData>(jQueryEvent e, jQueryDataHttpRequest<TData> request, jQueryAjaxOptions options);

    /// <summary>
    /// Handles ajax error events.
    /// </summary>
    /// <param name="e">The event information.</param>
    /// <param name="request">The request instance.</param>
    /// <param name="options">The Ajax options associated with the request.</param>
    /// <param name="error">The error information.</param>
    public delegate void AjaxErrorEventHandler(jQueryEvent e, jQueryXmlHttpRequest request, jQueryAjaxOptions options, Exception error);

    /// <summary>
    /// Handles ajax error events.
    /// </summary>
    /// <param name="e">The event information.</param>
    /// <param name="request">The request instance.</param>
    /// <param name="options">The Ajax options associated with the request.</param>
    /// <param name="error">The error information.</param>
    public delegate void AjaxErrorEventHandler<TData>(jQueryEvent e, jQueryDataHttpRequest<TData> request, jQueryAjaxOptions options, Exception error);
}
