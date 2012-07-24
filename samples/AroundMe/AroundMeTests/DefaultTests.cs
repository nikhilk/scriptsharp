// DefaultTests.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace AroundMeTests {

    [TestClass]
    [DeploymentItem("AroundMeTests\\Web", "Web")]
    [DeploymentItem("AroundMe\\bin\\Debug\\mscorlib.debug.js", "Web")]
    [DeploymentItem("AroundMe\\bin\\Debug\\AroundMe.test.js", "Web")]
    public class DefaultTests {

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
        public void TestMethod1() {
            WebTestPageBuilder pageBuilder = new WebTestPageBuilder("DefaultTests");
            string html =
                pageBuilder.AddScripts("mscorlib.debug.js", "AroundMe.test.js")
                           .ToHtml();

            Uri pageUri = _webTest.CreateContent("/DefaultTests.htm", html, "text/html");

            WebTestResult chromeResult = _webTest.RunTest(pageUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);
        }
    }
}
