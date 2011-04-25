// ScriptExtensions.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Web;
using System.Web.Mvc;
using ScriptSharp.Web.Configuration;
using ScriptSharp.Web.Script;

namespace ScriptSharp.Web {

    public static class ScriptExtensions {

        private const string LoaderScriptName = "loader";

        public static void AddScriptlet(this AjaxHelper ajaxHelper, string scriptletType) {
            ajaxHelper.AddScriptlet(scriptletType, null);
        }

        public static void AddScriptlet(this AjaxHelper ajaxHelper, string scriptletType, object parameters) {
            ScriptModel scriptModel = GetScriptModel(ajaxHelper);

            if (String.IsNullOrEmpty(scriptletType)) {
                throw new ArgumentNullException("scriptletType");
            }

            scriptModel.AddScriptlet(new Scriptlet(scriptletType, parameters));
        }

        public static void AddScriptReference(this AjaxHelper ajaxHelper, string scriptName) {
            ajaxHelper.AddScriptReference(scriptName, ScriptMode.Startup);
        }

        public static void AddScriptReference(this AjaxHelper ajaxHelper, string scriptName, ScriptMode scriptMode) {
            ScriptModel scriptModel = GetScriptModel(ajaxHelper);

            if (String.IsNullOrEmpty(scriptName)) {
                throw new ArgumentNullException("scriptName");
            }

            ScriptSharpSection configSection = ScriptSharpSection.GetSettings();
            ScriptElement scriptElement = configSection.Scripts.GetElement(scriptName, scriptModel.ScriptFlavor);
            string actualFlavor = String.Empty;

            int flavorIndex = scriptElement.Name.IndexOf('.');
            if (flavorIndex > 0) {
                actualFlavor = scriptElement.Name.Substring(flavorIndex + 1);
            }

            ScriptReference scriptReference =
                new ScriptReference(scriptName, scriptElement.Url, scriptMode,
                                    scriptElement.GetDependencyList(), scriptElement.Version + actualFlavor);
            scriptModel.AddScriptReference(scriptReference);
        }

        public static void AddStartupScript(this AjaxHelper ajaxHelper, string script) {
            ajaxHelper.AddStartupScript(script, null);
        }

        public static void AddStartupScript(this AjaxHelper ajaxHelper, string script, string[] dependencies) {
            ScriptModel scriptModel = GetScriptModel(ajaxHelper);

            if (String.IsNullOrEmpty(script)) {
                throw new ArgumentNullException("script");
            }

            scriptModel.AddScriptBlock(new ScriptBlock(script, dependencies));
        }

        public static bool CanInlineScripts(this AjaxHelper ajaxHelper) {
            if (ajaxHelper == null) {
                throw new ArgumentNullException("ajaxHelper");
            }

            ScriptSharpSection configSection = ScriptSharpSection.GetSettings();
            if (String.IsNullOrEmpty(configSection.ClientScriptStorageCookie) == false) {
                return ScriptInliner.SupportsLocalStorage(ajaxHelper.ViewContext.HttpContext);
            }

            return false;
        }

        public static string GetInlinedScriptsCookie(this AjaxHelper ajaxHelper) {
            return ScriptSharpSection.GetSettings().ClientScriptStorageCookie;
        }

        private static ScriptModel GetScriptModel(AjaxHelper ajaxHelper) {
            if (ajaxHelper == null) {
                throw new ArgumentNullException("ajaxHelper");
            }

            ScriptModel scriptModel = (ScriptModel)ajaxHelper.ViewContext.HttpContext.Items[typeof(ScriptModel)];
            if (scriptModel == null) {
                throw new InvalidOperationException("You must call InitializeScripts before calling adding scripts.");
            }

            return scriptModel;
        }

        public static void InitializeScripts(this AjaxHelper ajaxHelper) {
            ajaxHelper.InitializeScripts(ScriptFlavor.Release);
        }

        public static void InitializeScripts(this AjaxHelper ajaxHelper, ScriptFlavor scriptFlavor) {
            ajaxHelper.InitializeScripts(scriptFlavor, /* enableInlining */ false);
        }

        public static void InitializeScripts(this AjaxHelper ajaxHelper, ScriptFlavor scriptFlavor, bool enableInlining) {
            string scriptFlavorName = String.Empty;
            if (scriptFlavor == ScriptFlavor.Debug) {
                scriptFlavorName = "debug";
            }

            ajaxHelper.InitializeScripts(scriptFlavorName, enableInlining);
        }

        public static void InitializeScripts(this AjaxHelper ajaxHelper, string scriptFlavor) {
            ajaxHelper.InitializeScripts(scriptFlavor, /* enableInlining */ false);
        }

        public static void InitializeScripts(this AjaxHelper ajaxHelper, string scriptFlavor, bool enableInlining) {
            if (ajaxHelper == null) {
                throw new ArgumentNullException("ajaxHelper");
            }

            HttpContextBase httpContext = ajaxHelper.ViewContext.HttpContext;

            if (httpContext.Items[typeof(ScriptModel)] != null) {
                throw new InvalidOperationException("You must call InitializeScripts only once.");
            }

            ScriptSharpSection configSection = ScriptSharpSection.GetSettings();
            ScriptElement coreScriptElement = configSection.Scripts.GetElement(LoaderScriptName, scriptFlavor);

            ScriptInliner scriptInliner = null;
            if (enableInlining) {
                string storageCookieName = configSection.ClientScriptStorageCookie;
                if (String.IsNullOrEmpty(storageCookieName) == false) {
                    scriptInliner = new ScriptInliner(httpContext, storageCookieName);
                }
            }

            ScriptModel scriptModel = new ScriptModel(coreScriptElement.Url, scriptFlavor, scriptInliner);
            httpContext.Items[typeof(ScriptModel)] = scriptModel;
        }

        public static void RenderScripts(this AjaxHelper ajaxHelper) {
            ScriptModel scriptModel = GetScriptModel(ajaxHelper);

            scriptModel.IncludeDependencies(ScriptSharpSection.GetSettings().Scripts);
            scriptModel.Render(ajaxHelper.ViewContext.Writer);
        }
    }
}
