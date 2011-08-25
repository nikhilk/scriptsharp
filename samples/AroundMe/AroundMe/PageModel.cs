// PageModel.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Serialization;
using AroundMe.Core;
using AroundMe.DataModel;
using AroundMe.Services;

namespace AroundMe {

    internal sealed class PageModel : Model {

        private IFlickrService _flickr;
        private IStorageService _storage;

        private bool _searching;

        private List<Photo> _photos;
        private List<Photo> _favoritePhotos;
        private Photo _selectedPhoto;

        public PageModel(IFlickrService flickr, IStorageService storage) {
            _flickr = flickr;
            _storage = storage;

            _photos = new List<Photo>();
        }

        public List<Photo> Photos {
            get {
                return _photos;
            }
            private set {
                _photos = value;
                RaisePropertyChanged("Photos");
            }
        }

        public bool Searching {
            get {
                return _searching;
            }
            private set {
                _searching = value;
                RaisePropertyChanged("Searching");
            }
        }

        public Photo SelectedPhoto {
            get {
                return _selectedPhoto;
            }
            set {
                _selectedPhoto = value;
            }
        }

        public void AddFavorite() {
            if (_selectedPhoto == null) {
                return;
            }

            LoadFavorites();

            _favoritePhotos.Add(_selectedPhoto);
            SaveFavorites();
        }

        private void LoadFavorites() {
            if (_favoritePhotos == null) {
                try {
                    string favoriteData = _storage.GetValue("favorites");
                    if (String.IsNullOrEmpty(favoriteData) == false) {
                        _favoritePhotos = Json.ParseData<List<Photo>>(favoriteData);
                    }
                }
                catch {
                    Debug.Fail("Failed to load favorites");
                }
            }

            if (_favoritePhotos == null) {
                _favoritePhotos = new List<Photo>();
            }
        }

        private void SaveFavorites() {
            string favoritesData = Json.Stringify(_favoritePhotos);
            _storage.SetValue("favorites", favoritesData);
        }

        public void ShowFavorites() {
            LoadFavorites();
            Photos = _favoritePhotos;
        }

        public void ResetSearch() {
            Photos = new List<Photo>();
        }

        public void SearchLocation(string tags, double latitude, double longitude) {
            Searching = true;
            _flickr.SearchLocation(tags, latitude, longitude, SearchCompleted);
        }

        public void SearchRegion(string text, double latitude1, double longitude1, double latitude2, double longitude2) {
            Searching = true;
            _flickr.SearchRegion(text, latitude1, longitude1, latitude2, longitude2, SearchCompleted);
        }

        private void SearchCompleted(IEnumerable<PhotoResult> photoResults) {
            List<Photo> photos = new List<Photo>();

            foreach (PhotoResult photoResult in photoResults) {
                Photo photo = new Photo(photoResult.ID, photoResult.Title, photoResult.tags,
                                        photoResult.Url_p,
                                        photoResult.Url_m, Int32.Parse(photoResult.Width_m), Int32.Parse(photoResult.Height_m),
                                        photoResult.Url_sq,
                                        photoResult.Latitude, photoResult.Longitude);
                photos.Add(photo);
            }

            Searching = false;
            Photos = photos;
        }
    }
}
