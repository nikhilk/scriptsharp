// DefaultTests.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace AroundMeTests {

    [TestClass]
    public class DefaultTests {

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

            string testContentRoot = Path.GetFullPath(Path.Combine(testContext.TestRunDirectory, "..\\..\\AroundMeTests\\Web"));
            string scriptsRoot = Path.GetFullPath(Path.Combine(testContext.TestRunDirectory, "..\\..\\AroundMe\\bin\\Debug"));

            _webTest = new WebTest();
            _webTest.StartWebServer(Port, testContentRoot, scriptsRoot);
        }

        [ClassCleanup()]
        public static void OnCleanup() {
            _webTest.StopWebServer();
        }

        [TestMethod]
        public void TestMethod1() {
            Uri pageUri = _webTest.GetTestUri("/DefaultTests.htm");

            WebTestResult chromeResult = _webTest.RunTest(pageUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);
        }
    }
}
