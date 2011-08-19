// Photo.cs
//

using System;

namespace AroundMe.DataModel {

    /// <summary>
    /// Represents a geo-tagged photo along with various bits of metadata.
    /// </summary>
    internal sealed class Photo : Record {

        /// <summary>
        /// The ID of the photo.
        /// </summary>
        public string id;

        /// <summary>
        /// The text description of the photo.
        /// </summary>
        public string title;

        /// <summary>
        /// The URL of the page associated with the photo.
        /// </summary>
        public string url;

        /// <summary>
        /// The URL of the thumbnail of the photo.
        /// </summary>
        public string thumbnailUrl;

        /// <summary>
        /// The URL of the image itself.
        /// </summary>
        public string imageUrl;

        /// <summary>
        /// The width of the photo.
        /// </summary>
        public int width;

        /// <summary>
        /// The height of the photo.
        /// </summary>
        public int height;

        /// <summary>
        /// The latitude part of the geo-tag information.
        /// </summary>
        public double latitude;

        /// <summary>
        /// The longitude part of the geo-tag information.
        /// </summary>
        public double longitude;

        /// <summary>
        /// The set of tags associated with the photo.
        /// </summary>
        public string tags;

        public Photo(string id, string title, string tags, string url, string imageUrl, int width, int height, string thumbnailUrl, double latitude, double longitude) {
            this.id = id;
            this.title = title;
            this.tags = tags;
            this.url = url;
            this.imageUrl = imageUrl;
            this.width = width;
            this.height = height;
            this.thumbnailUrl = thumbnailUrl;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
