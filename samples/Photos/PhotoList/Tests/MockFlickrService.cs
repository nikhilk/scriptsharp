// MockFlickrService.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Testing;
using Flickr.FlickrClient;

namespace Gallery.Tests {

    public sealed class MockFlickrService : IFlickrService {

        private List<PhotoResult> _photos;

        public MockFlickrService(List<PhotoResult> photos) {
            _photos = photos;
        }

        public void SearchPhotos(string tags, int count, FlickrSearchCallback callback) {
            Script.SetTimeout(delegate() {
                callback(_photos);
            }, 0);
        }
    }
}
