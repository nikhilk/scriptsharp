// jQueryAjaxOptions.cs
// Script#/Libraries/jQuery/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi {

    /// <summary>
    /// Represents Ajax request settings or options.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
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
        /// Gets or sets the content type sent in the request header that tells the server what kind of response it will accept in return.
        /// </summary>
        [ScriptField]
        public Dictionary<string, string> Accepts {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the request is async.
        /// </summary>
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
        public AjaxCompletedCallback Complete {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets a map of string/regular-expression pairs that determine how jQuery will parse the response, given its content type.
        /// </summary>
        [ScriptField]
        public Dictionary<string, RegExp> Contents {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the content type of the data sent to the server.
        /// </summary>
        [ScriptField]
        public string ContentType {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the object that will be the context for the request.
        /// </summary>
        [ScriptField]
        public object Context {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets a map of dataType-to-dataType converters.
        /// </summary>
        [ScriptField]
        public Dictionary<string, Func<string, object>> Converters {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets if you wish to force a crossDomain request (such as JSONP) on the same domain, set the value of crossDomain to true
        /// </summary>
        [ScriptField]
        public bool CrossDomain {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the data to be sent to the server.
        /// </summary>
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
        public bool Global {
            get {
                return false;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets if a map of additional header key/value pairs to send along with the request.
        /// </summary>
        [ScriptField]
        public Dictionary<string, string> Headers {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets whether the request is successful only if its been modified since
        /// the last request.
        /// </summary>
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
        public string ScriptCharset {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets a map of numeric HTTP codes and functions to be called when the response has the corresponding code.
        /// </summary>
        [ScriptField]
        public Dictionary<int, Action> StatusCode {
            get {
                return null;
            }
            set {
            }
        }

        /// <summary>
        /// Gets or sets the function to invoke upon successful completion of the request.
        /// </summary>
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
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
        [ScriptField]
        public Dictionary<string, object> XhrFields {
            get {
                return null;
            }
            set {
            }
        }
    }
}
