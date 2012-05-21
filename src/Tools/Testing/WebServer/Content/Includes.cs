// Includes.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;

namespace ScriptSharp.Testing.WebServer.Content {

    internal static class Includes {

        private static readonly string _qunitExtensionsScript;
        private static readonly string _qunitScript;
        private static readonly string _qunitStyleSheet;

        static Includes() {
            string prefix = typeof(Includes).Namespace + ".";
            using (Stream s = typeof(Includes).Assembly.GetManifestResourceStream(prefix + "QUnitExt.js")) {
                _qunitExtensionsScript = (new StreamReader(s)).ReadToEnd();
            }
            using (Stream s = typeof(Includes).Assembly.GetManifestResourceStream(prefix + "QUnit.js")) {
                _qunitScript = (new StreamReader(s)).ReadToEnd();
            }
            using (Stream s = typeof(Includes).Assembly.GetManifestResourceStream(prefix + "QUnit.css")) {
                _qunitStyleSheet = (new StreamReader(s)).ReadToEnd();
            }
        }

        public static string QUnitExtensionsScript {
            get {
                return _qunitExtensionsScript;
            }
        }

        public static string QUnitScript {
            get {
                return _qunitScript;
            }
        }

        public static string QUnitStyleSheet {
            get {
                return _qunitStyleSheet;
            }
        }
    }
}
