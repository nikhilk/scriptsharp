// ExpressApplication.cs
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
    [ScriptName("express")]
    public sealed class ExpressApplication {

        private ExpressApplication() {
        }

        [ScriptField]
        public Dictionary<string, object> Locals {
            get {
                return null;
            }
        }

        [ScriptField]
        public Dictionary<string, List<ExpressRoute>> Routes {
            get {
                return null;
            }
        }

        [ScriptName("locals")]
        public void AddLocals(Dictionary<string, object> values) {
        }

        public ExpressApplication All(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication All(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication All(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication All(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Configure(Action callback) {
            return null;
        }

        public ExpressApplication Configure(string environmentName, Action callback) {
            return null;
        }

        public ExpressApplication Delete(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Delete(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Delete(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Delete(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        [ScriptName("disable")]
        public ExpressApplication DisableSetting(string name) {
            return null;
        }

        [ScriptName("disable")]
        public ExpressApplication DisableSetting(ExpressSettings name) {
            return null;
        }

        [ScriptName("enable")]
        public ExpressApplication EnableSetting(string name) {
            return null;
        }

        [ScriptName("enable")]
        public ExpressApplication EnableSetting(ExpressSettings name) {
            return null;
        }

        public ExpressApplication Engine(string extension, ExpressTemplateEngine engine) {
            return null;
        }

        public ExpressApplication Error(ExpressErrorHandler handler) {
            return null;
        }

        public ExpressApplication Error(ExpressChainedErrorHandler chainedHandler) {
            return null;
        }

        public ExpressApplication Get(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Get(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Get(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Get(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        [ScriptName("get")]
        public string GetSetting(string name) {
            return null;
        }

        [ScriptName("get")]
        public string GetSetting(ExpressSettings name) {
            return null;
        }

        public ExpressApplication Head(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Head(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Head(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Head(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        [ScriptName("disabled")]
        public bool IsSeSettingDisabled(string name) {
            return false;
        }

        [ScriptName("disabled")]
        public bool IsSeSettingDisabled(ExpressSettings name) {
            return false;
        }

        [ScriptName("enabled")]
        public bool IsSeSettingEnabled(string name) {
            return false;
        }

        [ScriptName("enabled")]
        public bool IsSeSettingEnabled(ExpressSettings name) {
            return false;
        }

        public void Listen(int port) {
        }

        public void Listen(int port, string hostName) {
        }

        public void Listen(int port, string hostName, int backlog) {
        }

        public ExpressApplication Param(string parameter, ExpressParameterHandler handler) {
            return null;
        }

        public ExpressApplication Options(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Options(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Options(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Options(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Post(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Post(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Post(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Post(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Put(string path, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Put(string path, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Put(RegExp pathPattern, ExpressHandler handler) {
            return null;
        }

        public ExpressApplication Put(RegExp pathPattern, ExpressChainedHandler[] chainedHandlers, ExpressHandler handler) {
            return null;
        }

        public void Render(string viewName, AsyncResultCallback<string> callback) {
        }

        public void Render(string viewName, Dictionary<string, object> data, AsyncResultCallback<string> callback) {
        }

        [ScriptName("set")]
        public void SetSetting(string name, string value) {
        }

        [ScriptName("set")]
        public void SetSetting(ExpressSettings name, string value) {
        }

        [ScriptSkip]
        public HttpListener ToHttpListener() {
            return null;
        }

        public ExpressApplication Use(ExpressMiddleware middleware) {
            return null;
        }

        public ExpressApplication Use(string path, ExpressMiddleware middleware) {
            return null;
        }
    }
}
