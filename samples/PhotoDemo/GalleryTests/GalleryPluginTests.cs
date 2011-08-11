// GalleryPluginTests.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace GalleryTests {

    [TestClass]
    [DeploymentItem("GalleryTests\\Web", "Web")]
    [DeploymentItem("Gallery\\bin\\debug\\mscorlib.js", "Web")]
    [DeploymentItem("Gallery\\bin\\debug\\Flickr.js", "Web")]
    [DeploymentItem("Gallery\\bin\\debug\\Gallery.test.js", "Web")]
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
            Uri testUri = _webTest.GetTestUri("/Gallery.htm");

            WebTestResult chromeResult = _webTest.RunTest(testUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);

            WebTestResult ffResult = _webTest.RunTest(testUri, WebBrowser.Firefox);
            Assert.IsTrue(ffResult.Succeeded, "Firefox:\r\n" + ffResult.Log);
        }
    }
}
