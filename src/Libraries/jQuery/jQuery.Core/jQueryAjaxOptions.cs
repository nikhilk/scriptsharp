// jQueryAjaxOptions.cs
// Script#/Libraries/jQuery/jQueryCore
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents Ajax request settings or options.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public sealed class jQueryAjaxOptions {

        /// <summary>
        /// Initializes an empty instance of a jQueryAjaxOptions object.
        /// </summary>
        public jQueryAjaxOptions() {
        }

        /// <summary>
        /// Initializes an instance of a jQueryAjaxOptions object with the
        /// specified name/value pair list of fields.
        /// </summary>
        /// <param name="nameValuePairs">An alternating set of string names and object values.</param>
        public jQueryAjaxOptions(params object[] nameValuePairs) {
        }

        /// <summary>
        /// Gets or sets whether the request is async.
        /// </summary>
        [IntrinsicProperty]
        public bool Async {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the callback to invoke before the request is sent.
        /// </summary>
        [IntrinsicProperty]
        public AjaxSendingCallback BeforeSend {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the request can be cached.
        /// </summary>
        [IntrinsicProperty]
        public bool Cache {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the callback invoked after the request is completed
        /// and success or error callbacks have been invoked.
        /// </summary>
        [IntrinsicProperty]
        public AjaxCompletedCallback Complete {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the content type of the data sent to the server.
        /// </summary>
        [IntrinsicProperty]
        public string ContentType {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the element that will be the context for the request.
        /// </summary>
        [IntrinsicProperty]
        public Element Context {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the data to be sent to the server.
        /// </summary>
        [IntrinsicProperty]
        public object Data {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the data type expected in response from the server.
        /// </summary>
        [IntrinsicProperty]
        public string DataType {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the callback to be invoked if the request fails.
        /// </summary>
        [IntrinsicProperty]
        public AjaxErrorCallback Error {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether to trigger global event handlers for this Ajax request.
        /// </summary>
        [IntrinsicProperty]
        public bool Global {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the request is successful only if its been modified since
        /// the last request.
        /// </summary>
        [IntrinsicProperty]
        public bool IfModified {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the current environment should be treated as a local
        /// environment (eg. when the page is loaded using file:///).
        /// </summary>
        [IntrinsicProperty]
        public bool IsLocal {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the callback parameter name to use for JSONP requests.
        /// </summary>
        [IntrinsicProperty]
        public string Jsonp {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the callback name to use for JSONP requests.
        /// </summary>
        [IntrinsicProperty]
        public string JsonpCallback {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the mime type of the request.
        /// </summary>
        [IntrinsicProperty]
        public string MimeType {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the password to be used for an HTTP authentication request.
        /// </summary>
        [IntrinsicProperty]
        public string Password {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the data passed in will be processed.
        /// </summary>
        [IntrinsicProperty]
        public bool ProcessData {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets how to handle character sets for script and JSONP requests.
        /// </summary>
        [IntrinsicProperty]
        public string ScriptCharset {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the function to invoke upon successful completion of the request.
        /// </summary>
        [IntrinsicProperty]
        public AjaxRequestCallback Success {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the timeout in milliseconds for the request.
        /// </summary>
        [IntrinsicProperty]
        public int Timeout {
            get {
                return 0;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets if you want to use traditional parameter serialization.
        /// </summary>
        [IntrinsicProperty]
        public bool Traditional {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the type or HTTP verb associated with the request.
        /// </summary>
        [IntrinsicProperty]
        public string Type {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the URL to be requested.
        /// </summary>
        [IntrinsicProperty]
        public string Url {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the name of the user to use in a HTTP authentication request.
        /// </summary>
        [IntrinsicProperty]
        public string Username {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the function creating the XmlHttpRequest instance.
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("xhr")]
        public XmlHttpRequestCreator XmlHttpRequestCreator {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets a set of additional name/value pairs set of the XmlHttpRequest
        /// object.
        /// </summary>
        [IntrinsicProperty]
        public Dictionary XhrFields {
            get {
                return null;
            }
            set {
            }
        }
    }
}
