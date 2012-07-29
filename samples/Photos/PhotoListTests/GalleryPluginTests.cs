// GalleryPluginTests.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace PhotoListTests {

    [TestClass]
    [DeploymentItem("PhotoListTests\\Web", "Web")]
    [DeploymentItem("PhotoList\\bin\\debug\\mscorlib.js", "Web")]
    [DeploymentItem("PhotoList\\bin\\debug\\Photos.debug.js", "Web")]
    [DeploymentItem("PhotoList\\bin\\debug\\PhotoList.test.js", "Web")]
    public class GalleryPluginTests {

        private static WebTest _webTest;

        public TestContext TestContext {
            get;
            set;
        }

        [ClassInitialize()]
        public static void OnInitialize(TestContext testContext) {
            // This starts the web server rooted at the specified directory
            // on http://localhost:<port>

            string webRoot = Path.Combine(testContext.DeploymentDirectory, "Web");
            int port = 3976;

            _webTest = new WebTest();
            _webTest.StartWebServer(webRoot, port);
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
