// FlickrService.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace PhotoGrid.Flickr {

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
        public string Url_t;
        public string Height_m;
        public string Width_m;
        public string Height_t;
        public string Width_t;
    }

    internal sealed class FlickrService {

        private static string SearchUriFormat = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&sort=interestingness-desc&safe_search=1&extras=o_dims%2Curl_sq%2Curl_m%2Curl_t&per_page={2}&format=json";
        private static string Base58Alphabet = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
        private string _apiKey;

        public FlickrService(string apiKey) {
            _apiKey = apiKey;
        }

        private static string Base58Encode(string id) {
            int number = Int32.Parse(id);

            string encoded = "";
            while (number > 0) {
                int remainder = number % Base58Alphabet.Length;
                number = (int)(number / Base58Alphabet.Length);
                encoded = Base58Alphabet.CharAt(remainder) + encoded;
            }

            return encoded;
        }

        public IDeferred<IEnumerable<Photo>> SearchPhotos(string tags, int count) {
            jQueryAjaxOptions ajaxOptions =
                new jQueryAjaxOptions("url", String.Format(SearchUriFormat, _apiKey, tags.EncodeUriComponent(), count),
                                      "jsonp", "jsoncallback",
                                      "dataType", "jsonp");
            return jQuery.AjaxRequest<SearchResponse>(ajaxOptions).Pipe<IEnumerable<Photo>>(
                delegate(SearchResponse response) {
                    List<Photo> photos =
                        response.PhotoResponse.PhotoList.Map<Photo>(delegate(PhotoResult photoResult) {
                            return new Photo(photoResult.ID,
                                             photoResult.Title,
                                             "http://flic.kr/p/" + Base58Encode(photoResult.ID),
                                             photoResult.Url_m,
                                             photoResult.Url_t,
                                             Int32.Parse(photoResult.Width_m),
                                             Int32.Parse(photoResult.Height_m),
                                             Int32.Parse(photoResult.Width_t),
                                             Int32.Parse(photoResult.Height_t));
                    });

                    return photos;
                });
        }
    }
}
