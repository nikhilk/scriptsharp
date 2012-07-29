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
    // TODO: Add other deployment items that are needed for the test, to be
    //       placed within the web site created for the test.
    //       For example, mscorlib scripts, test scripts and dependencies
    //       The first parameter to DeploymentItem is a solution-relative
    //       path to the file, and the 2nd parameter is to deployment directory
    //       relative to the test output directory.
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
            // TestClass1.htm is in the Web directory, and gets deployed along with all
            // content of the Web directory per the metadata on the class.
            // You need to edit it to include HTML content and scripts you need to run
            // the test.
            Uri testUri = _webTest.GetTestUri("/TestClass1.htm");

            // Alternatively you can also use _webTest.CreatePage to register some
            // content you create dynamically in the test for serving from the web server.

            WebTestResult ieResult = _webTest.RunTest(testUri, WebBrowser.InternetExplorer);
            Assert.IsTrue(ieResult.Succeeded, "Internet Explorer:\r\n" + ieResult.Log);

            WebTestResult chromeResult = _webTest.RunTest(testUri, WebBrowser.Chrome);
            Assert.IsTrue(chromeResult.Succeeded, "Chrome:\r\n" + chromeResult.Log);

            WebTestResult ffResult = _webTest.RunTest(testUri, WebBrowser.Firefox);
            Assert.IsTrue(ffResult.Succeeded, "Firefox:\r\n" + ffResult.Log);
        }
    }
}
