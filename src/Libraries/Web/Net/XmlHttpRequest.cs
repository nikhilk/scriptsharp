// XMLHttpRequest.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace System.Net {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("XMLHttpRequest")]
    public sealed class XmlHttpRequest {

        [IntrinsicProperty]
        [ScriptName("onreadystatechange")]
        public Action OnReadyStateChange {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public ReadyState ReadyState {
            get {
                return ReadyState.Uninitialized;
            }
        }

        [IntrinsicProperty]
        [ScriptName("responseXML")]
        public XmlDocument ResponseXml {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string ResponseText {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int Status {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string StatusText {
            get {
                return null;
            }
        }

        public void Abort() {
        }

        public string GetAllResponseHeaders() {
            return null;
        }

        public string GetResponseHeader(string name) {
            return null;
        }

        public void Open(string method, string url) {
        }

        public void Open(HttpVerb verb, string url) {
        }

        public void Open(string method, string url, bool async) {
        }

        public void Open(HttpVerb verb, string url, bool async) {
        }

        public void Open(string method, string url, bool async, string userName, string password) {
        }

        public void Open(HttpVerb verb, string url, bool async, string userName, string password) {
        }

        public void Send() {
        }

        public void Send(string body) {
        }

        public void SetRequestHeader(string name, string value) {
        }
    }
}
