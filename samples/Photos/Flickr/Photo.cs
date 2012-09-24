// Photo.cs
//

using System;
using System.Runtime.CompilerServices;

namespace Flickr {

    /// <summary>
    /// Represents a geo-tagged photo along with various bits of metadata.
    /// </summary>
    [ScriptObject]
    public sealed class Photo {

        public string id;

        public string title;

        public string url;
        public string thumbnailUrl;
        public string imageUrl;
        public string squareImageUrl;

        public int imageWidth;
        public int imageHeight;

        public int thumbnailWidth;
        public int thumbnailHeight;

        public Photo(string id, string title, string url, string imageUrl, string thumbnailUrl, int imageWidth, int imageHeight, int thumbnailWidth, int thumbnailHeight, string squareImageUrl) {
            this.id = id;
            this.title = title;
            this.url = url;
            this.imageUrl = imageUrl;
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.thumbnailWidth = thumbnailWidth;
            this.thumbnailHeight = thumbnailHeight;
            this.thumbnailUrl = thumbnailUrl;
            this.squareImageUrl = squareImageUrl;
        }
    }
}
