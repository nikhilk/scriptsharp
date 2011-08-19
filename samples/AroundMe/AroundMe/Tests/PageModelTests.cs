// PageModelTests.cs
//

using System;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Testing;
using AroundMe.Services;

namespace AroundMe.Tests {

    [SuppressMessage("Microsoft.Performance", "CA1812",
                     Justification = "Tests don't have internal consumers. They're only compiled into .test.js scripts.")]
    internal sealed class PageModelTests : TestClass {

        public void TestSearchLocationTogglesSearchingStatus() {
            Assert.ExpectAsserts(2);

            MockFlickrService flickrService = new MockFlickrService();
            PageModel pageModel = new PageModel(flickrService, null);

            pageModel.SearchLocation("xyz", 0, 0);
            Assert.IsTrue(pageModel.Searching, "Expected model to report true for Searching.");

            Window.SetTimeout(delegate() {
                PhotoResult[] dummyResults = new PhotoResult[0];

                flickrService.InvokeCallback(dummyResults);
                Assert.IsTrue(pageModel.Searching == false, "Expected model to report false for Searching.");

                TestEngine.ResumeOnAsyncCompleted();
            }, 2000);

            TestEngine.WaitForAsyncCompletion();
        }
    }
}
