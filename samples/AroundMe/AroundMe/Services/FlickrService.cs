// FlickrService.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace AroundMe.Services {

    [Imported]
    public sealed class SearchResponse {

        [ScriptName("photos")]
        public PhotosSearchResponse PhotoResponse;
    }

    [Imported]
    public sealed class PhotosSearchResponse {

        [ScriptName("photo")]
        public List<PhotoResult> PhotoList;
    }

    [Imported]
    public sealed class PhotoResult {

        public string ID;
        public string Owner;
        public string Title;
        public string Url_sq;
        public string Url_m;
        public string Height_m;
        public string Width_m;
        public double Latitude;
        public double Longitude;
        public string tags;

        public string Url_p;
    }

    internal sealed class FlickrService : IFlickrService {

        private static string RegionSearchUriFormat = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&tag_mode=all&has_geo=1&sort=interestingness-desc&safe_search=1&extras=o_dims%2Curl_sq%2Curl_m%2Cgeo%2Ctags&bbox={2}%2C{3}%2C{4}%2C{5}&per_page=20&format=json";
        private static string LocationSearchUriFormat = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&has_geo=true&sort=interestingness-desc&safe_search=1&extras=o_dims%2Curl_sq%2Curl_m%2Cgeo%2Ctags&lat={2}&lon={3}&per_page=20&format=json";
        private string _apiKey;

        public FlickrService(string apiKey) {
            _apiKey = apiKey;
        }

        public void SearchLocation(string tags, double latitude, double longitude, Action<IEnumerable<PhotoResult>> searchCallback) {
            string url = String.Format(LocationSearchUriFormat,
                                       _apiKey,
                                       tags.EncodeUriComponent(), latitude, longitude);
            Search(url, searchCallback);
        }

        public void SearchRegion(string text, double latitude1, double longitude1, double latitude2, double longitude2, Action<IEnumerable<PhotoResult>> searchCallback) {
            string tags = text.Split(' ').Join(",").EncodeUriComponent();
            string url = String.Format(RegionSearchUriFormat,
                                       _apiKey,
                                       tags, latitude1, longitude1, latitude2, longitude2);

            Search(url, searchCallback);
        }

        private static void Search(string url, Action<IEnumerable<PhotoResult>> searchCallback) {
            Action<SearchResponse> jsonCallback =
                delegate(SearchResponse response) {
                    List<PhotoResult> photos = response.PhotoResponse.PhotoList;

                    photos.ForEach(delegate(PhotoResult photo) {
                        string[] tagsArray = photo.tags.Split(' ');
                        if (tagsArray.Length > 10) {
                            tagsArray = (string[])tagsArray.Extract(0, 10);
                        }

                        photo.tags = tagsArray.Join(",");
                        photo.Url_p = "http://flic.kr/p/" + Base58.Encode(photo.ID);
                    });

                    searchCallback(photos);
                };

            string jsonCallbackName = Delegate.CreateExport(jsonCallback);
            string scriptSource = url + "&jsoncallback=" + jsonCallbackName;

            ScriptElement scriptElement = Document.CreateElement("script").As<ScriptElement>();
            scriptElement.Type = "text/javascript";
            scriptElement.Src = scriptSource;
            Document.GetElementsByTagName("head")[0].AppendChild(scriptElement);
        }
    }
}
