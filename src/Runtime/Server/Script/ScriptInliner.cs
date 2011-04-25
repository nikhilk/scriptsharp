// ScriptInliner.cs
// Script#/Runtime/Server
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Caching;
using ScriptSharp.Web.Core;

namespace ScriptSharp.Web.Script {

    internal sealed class ScriptInliner {

        private const string DefaultStorageCookieName = "scripts";

        private HttpContextBase _httpContext;
        private JsonObject _storageCookie;

        public ScriptInliner(HttpContextBase httpContext, string storageCookieName) {
            Debug.Assert(httpContext != null);

            _httpContext = httpContext;
            InitializeStorageCookie(storageCookieName);
        }

        public bool CanInlineScript(ScriptReference scriptReference) {
            return (String.IsNullOrEmpty(scriptReference.Version) == false) &&
                   (Uri.IsWellFormedUriString(scriptReference.Path, UriKind.Absolute) == false);
        }

        public string GetScript(ScriptReference scriptReference) {
            if (_storageCookie != null) {
                object value = _storageCookie[scriptReference.Name];
                if ((value != null) && (value is string) &&
                    (String.CompareOrdinal(scriptReference.Version, (string)value) == 0)) {
                    return null;
                }
            }

            string cacheKey = "ScriptContent:" + scriptReference.Name;
            string scriptContent = _httpContext.Cache[cacheKey] as string;

            if (scriptContent == null) {
                string filePath = _httpContext.Server.MapPath(scriptReference.Path);

                using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    scriptContent = (new StreamReader(stream)).ReadToEnd();
                }

                if (String.IsNullOrEmpty(scriptContent)) {
                    throw new InvalidOperationException("Unable to read script of script named '" + scriptReference.Name + "'.");
                }

                _httpContext.Cache.Insert(cacheKey, scriptContent, new CacheDependency(filePath));
            }

            return scriptContent;
        }

        private void InitializeStorageCookie(string storageCookieName) {
            if (String.IsNullOrEmpty(storageCookieName)) {
                storageCookieName = DefaultStorageCookieName;
            }

            HttpCookie rawStorageCookie = _httpContext.Request.Cookies[storageCookieName];
            if (rawStorageCookie != null) {
                try {
                    string cookie = HttpUtility.UrlDecode(rawStorageCookie.Value);

                    JsonReader jsonReader = new JsonReader(cookie);
                    _storageCookie = jsonReader.ReadValue() as JsonObject;
                }
                catch {
                }
            }
        }

        public static bool SupportsLocalStorage(HttpContextBase httpContext) {
            // TODO: This is a hacky implementation... to be fixed.
            //       Client script will check for existence of localStorage API.
            //       We just want to avoid obvious cases where inlining script
            //       is detrimental to startup.

            // http://diveintohtml5.org/storage.html
            // IE8+
            // Firefox 3.5+, Safari 4.0+, Chrome 4.0+, Opera 10.5+
            // iPhone 2.0+, Android 2.0+

            string ua = httpContext.Request.UserAgent;

            if ((ua.IndexOf("MSIE 8", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("MSIE 9", StringComparison.Ordinal) > 0)) {
                return true;
            }

            if ((ua.IndexOf("Firefox", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("Safari", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("Chrome", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("iPhone", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("iPad", StringComparison.Ordinal) > 0) ||
                (ua.IndexOf("Android", StringComparison.Ordinal) > 0)) {
                return true;
            }

            return false;
        }
    }
}
