// Flickr.cs
//

using System;
using System.Collections.Generic;
using System.Html;

namespace Flickr.FlickrClient {

    public interface IFlickrService {

        void SearchPhotos(string tags, int count, FlickrSearchCallback callback);
    }

    public sealed class FlickrService : IFlickrService {

        private const string FlickrSearchURLFormat =
            "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=be9b6f66bd7a1c0c0f1465a1b7e8a764&tags={0}&per_page={1}&sort=interestingness-desc&safe_search=1&content_type=1&in_gallery=true&extras=o_dims%2Curl_sq%2Curl_m&format=json&jsoncallback={2}";

        public void SearchPhotos(string tags, int count, FlickrSearchCallback callback) {
            FlickrCallback requestCallback = delegate(PhotoSearchResponse response) {
                callback(response.Photos.Results);
            };

            Export exportedDelegate = Delegate.Export(requestCallback);

            string url = String.Format(FlickrSearchURLFormat, tags.EncodeUriComponent(), count, exportedDelegate.Name);
            ScriptElement script = (ScriptElement)Document.CreateElement("script");
            script.Type = "text/javascript";
            script.Src = url;
            Document.GetElementsByTagName("head")[0].AppendChild(script);
        }
    }

    internal delegate void FlickrCallback(PhotoSearchResponse response);

    public delegate void FlickrSearchCallback(List<PhotoResult> photos);
}
