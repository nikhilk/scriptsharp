// MockPhotoService.cs
//

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Html;
using System.Testing;
using Flickr;

namespace Gallery.Tests {

    public sealed class MockPhotoService : IPhotoService {

        private Photo[] _photos;

        public MockPhotoService(Photo[] photos) {
            _photos = photos;
        }

        public void SearchPhotos(string tags, int count, FlickrSearchCallback callback) {
            Window.SetTimeout(delegate() {
                callback(_photos);
            }, 0);
        }
    }
}
