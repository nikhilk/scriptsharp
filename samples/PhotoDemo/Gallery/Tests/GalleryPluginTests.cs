// ListBuilderTests.cs
//

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Testing;
using jQueryApi;
using Flickr;
using Gallery;

namespace Gallery.Tests {

    [SuppressMessage("Microsoft.Performance", "CA1812",
                     Justification = "Tests don't have internal consumers. They're only compiled into .test.js scripts.")]
    internal sealed class GalleryPluginTests : TestClass {

        private jQueryObject _thumbsList;

        public override void Setup() {
            _thumbsList = jQuery.FromHtml("<ul id='thumbsList'></ul>");
            _thumbsList.AppendTo(Document.Body);
        }

        public override void Cleanup() {
            _thumbsList.Remove();
            _thumbsList = null;
        }

        public void TestEmptyCollection() {
            Assert.ExpectAsserts(1);

            GalleryPluginOptions options = new GalleryPluginOptions("thumbsListID", "thumbsList");
            options.photoService = new MockPhotoService(null);

            TestEngine.WaitForAsyncCompletion();

            jQuery.FromElement(Document.Body).Plugin<GalleryObject>().Gallery(options);

            Assert.AreEqual(_thumbsList.GetHtml().Trim().Length, 0, "Expected html to be empty for null photos array.");

            TestEngine.ResumeOnAsyncCompleted();
        }
    }
}
