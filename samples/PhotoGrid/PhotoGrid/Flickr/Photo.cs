// Photo.cs
//

using System;

namespace PhotoGrid.Flickr {

    /// <summary>
    /// Represents a geo-tagged photo along with various bits of metadata.
    /// </summary>
    internal sealed class Photo : Record {

        public string id;

        public string title;

        public string url;
        public string thumbnailUrl;
        public string imageUrl;

        public int imageWidth;
        public int imageHeight;

        public int thumbnailWidth;
        public int thumbnailHeight;

        public Photo(string id, string title, string url, string imageUrl, string thumbnailUrl, int imageWidth, int imageHeight, int thumbnailWidth, int thumbnailHeight) {
            this.id = id;
            this.title = title;
            this.url = url;
            this.imageUrl = imageUrl;
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.thumbnailWidth = thumbnailWidth;
            this.thumbnailHeight = thumbnailHeight;
            this.thumbnailUrl = thumbnailUrl;
        }
    }
}
