// Gallery.cs
//

using System;
using System.Collections;
using Flickr;
using System.Diagnostics;

namespace Interestingness {

    public class Gallery {

        private string _tags;
        private Photo[] _photos;
        private int _selectedIndex;

        public Gallery() {
            _tags = "Seattle";
            _selectedIndex = -1;

            UpdatePhotos();
        }

        public Photo[] Photos {
            get {
                return _photos;
            }
        }

        public Photo SelectedPhoto {
            get {
                if ((_photos == null) || (_selectedIndex > _photos.Length - 1)) {
                    return null;
                }
                return _photos[_selectedIndex];
            }
        }

        public string Tags {
            get {
                return _tags;
            }
            set {
                _tags = value;
                UpdatePhotos();
            }
        }

        public event EventHandler PhotoChanged;

        public void NextPhoto() {
            if ((_photos == null) || (_photos.Length == 0)) {
                return;
            }

            _selectedIndex++;
            if (_selectedIndex >= _photos.Length) {
                _selectedIndex = 0;
            }

            RaisePhotoChanged();
        }

        private void RaisePhotoChanged() {
            if (PhotoChanged != null) {
                PhotoChanged(this, EventArgs.Empty);
            }
        }

        private void UpdatePhotos() {
            FlickrService flickr = new FlickrService();
            flickr.SearchPhotos(_tags, 10, delegate(Photo[] photos) {
                if ((photos == null) || (photos.Length == 0)) {
                    return;
                }

                _photos = photos;
                _selectedIndex = 0;

                RaisePhotoChanged();
            });
        }
    }
}
