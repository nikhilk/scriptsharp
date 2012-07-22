// TestClass1.cs
//

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScriptSharp.Testing;

namespace $safeprojectname$ {

    [TestClass]
    [DeploymentItem("$projectname$\\Web", "Web")]
    public class TestClass1 {

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

        #region Per-test Initialization/Cleanup
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void OnTestInitialize() {
        // }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void OnTestCleanup() {
        // }
        //
        #endregion

        [TestMethod]
        public void TestMethod1() {
            Uri testUri = _webTest.GetTestUri("/Default.htm");

            WebTestResult ieResult = _webTest.RunTest(testUri, WebBrowser.InternetExplorer);
            Assert.IsTrue(ieResult.Succeeded, "Internet Explorer:\r\n" + ieResult.Log);

            WebTestResult chromeResult = _webTest.RunTest(testUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);

            WebTestResult ffResult = _webTest.RunTest(testUri, WebBrowser.Firefox);
            Assert.IsTrue(ffResult.Succeeded, "Firefox:\r\n" + ffResult.Log);
        }
    }
}
