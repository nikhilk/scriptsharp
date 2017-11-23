// BrowserTest.cs
// Script#/Tests
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace ScriptSharp.Tests.Core {

    public abstract class BrowserTest {

        private static readonly WebTest _webTest;
        private static readonly string[] _scripts = new string[] {
            "ss.js", "ss.min.js", "ssloader.js", "ssloader.min.js"
        };
        private static readonly string[] _codeFiles = new string[] {
            "OOP.cs"
        };
        private static string _compilationFailures;

        private const int _port = 3976;

        private TestContext _context;

        static BrowserTest() {
            string assemblyPath = typeof(BrowserTest).Assembly.GetModules()[0].FullyQualifiedName;
            string binDirectory = Path.GetFullPath(Path.Combine(assemblyPath, "..\\Test\\"));

            string webRoot = Path.GetFullPath(Path.Combine(assemblyPath, "..\\TestSite\\"));
            string scriptsDirectory = Path.Combine(webRoot, "Scripts");
            string codeDirectory = Path.Combine(webRoot, "Code");

            Directory.CreateDirectory(scriptsDirectory);
            foreach (string script in _scripts) {
                File.Copy(Path.Combine(binDirectory, script), Path.Combine(scriptsDirectory, script), overwrite: true);
            }

            List<string> codeFailures = new List<string>();

            string mscorlibPath = Path.Combine(binDirectory, "mscorlib.dll");
            foreach (string codeFile in _codeFiles) {
                string script = Path.GetFileNameWithoutExtension(codeFile) + Path.ChangeExtension(".cs", ".js");

                SimpleCompilation compilation = new SimpleCompilation(Path.Combine(scriptsDirectory, script));
                bool result = compilation.AddReference(mscorlibPath)
                                         .AddSource(Path.Combine(codeDirectory, codeFile))
                                         .Execute();

                if (result == false) {
                    codeFailures.Add(codeFile);
                }
            }

            _compilationFailures = (codeFailures.Count == 0) ? null : String.Join(", ", codeFailures);

            _webTest = new WebTest();
            _webTest.StartWebServer(_port, webRoot);
        }

        public TestContext TestContext {
            get {
                return _context;
            }
            set {
                _context = value;
            }
        }

        protected void RunTest(string url) {
            if (_compilationFailures != null) {
                Assert.Fail("Could not run test due to compilation failure of " + _compilationFailures + ".");
                return;
            }

            Uri testUri = _webTest.GetTestUri(url);

            WebTestResult result = _webTest.RunTest(testUri, WebBrowser.Chrome);
            Console.Write(result.Log);
            Assert.IsTrue(result.Succeeded, "Log:\n" + result.Log);
        }
    }
}
