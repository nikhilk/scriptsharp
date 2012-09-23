// XMLHttpRequest.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace System.Net {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("XMLHttpRequest")]
    public sealed class XmlHttpRequest {

        [ScriptProperty]
        [ScriptName("onreadystatechange")]
        public Action OnReadyStateChange {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public ReadyState ReadyState {
            get {
                return ReadyState.Uninitialized;
            }
        }

        [ScriptProperty]
        [ScriptName("responseXML")]
        public XmlDocument ResponseXml {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string ResponseText {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public int Status {
            get {
                return 0;
            }
        }

        [ScriptProperty]
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

        public void Open(string method, string url, bool @async) {
        }

        public void Open(HttpVerb verb, string url, bool @async) {
        }

        public void Open(string method, string url, bool @async, string userName, string password) {
        }

        public void Open(HttpVerb verb, string url, bool @async, string userName, string password) {
        }

        public void Send() {
        }

        public void Send(string body) {
        }

        public void SetRequestHeader(string name, string value) {
        }
    }
}
