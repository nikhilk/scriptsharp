// FlickrPhotoService.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;
using Photos.FlickrClient;

namespace Photos {

    public sealed class FlickrPhotoService : IPhotoService {

        private static string SearchUriFormat = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&sort=interestingness-desc&safe_search=1&extras=o_dims%2Curl_sq%2Curl_m%2Curl_t&per_page={2}&format=json";
        private static string Base58Alphabet = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
        private string _apiKey;

        public FlickrPhotoService() {
            _apiKey = "be9b6f66bd7a1c0c0f1465a1b7e8a764";
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
            return jQuery.AjaxRequest<PhotoSearchResponse>(ajaxOptions).Pipe<IEnumerable<Photo>>(
                delegate(PhotoSearchResponse response) {
                    List<Photo> photos =
                        response.Photos.Results.Map<Photo>(delegate(PhotoResult photoResult) {
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
