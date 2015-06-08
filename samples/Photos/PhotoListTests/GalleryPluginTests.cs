// GalleryPluginTests.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace PhotoListTests {

    [TestClass]
    public class GalleryPluginTests {

        private const int Port = 3976;

        private static WebTest _webTest;

        public TestContext TestContext {
            get;
            set;
        }

        [ClassInitialize()]
        public static void OnInitialize(TestContext testContext) {
            // This starts the web server rooted at the specified directory
            // on http://localhost:<port>

            string testContentRoot = Path.GetFullPath(Path.Combine(testContext.TestRunDirectory, "..\\..\\PhotoListTests\\Web"));
            string scriptsRoot = Path.GetFullPath(Path.Combine(testContext.TestRunDirectory, "..\\..\\PhotoList\\bin\\Debug"));

            _webTest = new WebTest();
            _webTest.StartWebServer(Port, testContentRoot, scriptsRoot);
        }

        [ClassCleanup()]
        public static void OnCleanup() {
            _webTest.StopWebServer();
        }

        [TestMethod]
        public void TestGallery() {
            Uri testUri = _webTest.GetTestUri("/GalleryPluginTests.htm");

            WebTestResult chromeResult = _webTest.RunTest(testUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);
        }
    }
}
