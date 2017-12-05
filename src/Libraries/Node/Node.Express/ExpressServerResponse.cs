// ExpressServerResponse.cs
// Script#/Libraries/Node/Express
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.Network;

namespace NodeApi.ExpressJS {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class ExpressServerResponse {

        private ExpressServerResponse() {
        }

        [ScriptField]
        public string Charset {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Dictionary<string, object> Locals {
            get {
                return null;
            }
        }

        [ScriptName("locals")]
        public void AddLocals(Dictionary<string, object> values) {
        }

        public ExpressServerResponse ClearCookie(string header) {
            return null;
        }

        public ExpressServerResponse ClearCookie(string header, object options) {
            return null;
        }

        [ScriptName("get")]
        public string GetHeader(string header) {
            return null;
        }

        public void Redirect(string url) {
        }

        public void Redirect(HttpStatusCode statusCode, string url) {
        }

        public void Render(string viewName, AsyncResultCallback<string> callback) {
        }

        public void Render(string viewName, Dictionary<string, object> data, AsyncResultCallback<string> callback) {
        }

        public void Send(object data) {
        }

        public void Send(HttpStatusCode statusCode) {
        }

        public void Send(HttpStatusCode statusCode, object data) {
        }

        public void SendFile(string path) {
        }

        public void SendFile(string path, object options) {
        }

        public void SendFile(string path, object options, AsyncCallback callback) {
        }

        [ScriptName("download")]
        public void SendFileAttachment(string path) {
        }

        [ScriptName("download")]
        public void SendFileAttachment(string path, string fileName) {
        }

        [ScriptName("download")]
        public void SendFileAttachment(string path, string fileName, AsyncCallback callback) {
        }

        [ScriptName("json")]
        public void SendJson(object data) {
        }

        [ScriptName("json")]
        public void SendJson(HttpStatusCode statusCode, object data) {
        }

        [ScriptName("jsonp")]
        public void SendJsonP(object data) {
        }

        [ScriptName("jsonp")]
        public void SendJsonP(HttpStatusCode statusCode, object data) {
        }

        [ScriptName("attachment")]
        public ExpressServerResponse SetAttachment() {
            return null;
        }

        [ScriptName("attachment")]
        public ExpressServerResponse SetAttachment(string fileName) {
            return null;
        }

        [ScriptName("cookie")]
        public ExpressServerResponse SetCookie(string header, string value) {
            return null;
        }

        [ScriptName("cookie")]
        public ExpressServerResponse SetCookie(string header, string value, ExpressCookieOptions options) {
            return null;
        }

        [ScriptName("set")]
        public ExpressServerResponse SetHeader(string header, string value) {
            return null;
        }

        [ScriptName("set")]
        public ExpressServerResponse SetHeaders(Dictionary<string, string> headers) {
            return null;
        }

        [ScriptName("links")]
        public ExpressServerResponse SetLinks(Dictionary<string, string> links) {
            return null;
        }

        [ScriptName("status")]
        public ExpressServerResponse SetStatus(HttpStatusCode code) {
            return null;
        }

        [ScriptName("type")]
        public ExpressServerResponse SetType(string type) {
            return null;
        }
    }
}
