// GadgetScriptlet.cs
//

using System;
using System.Collections;
using System.Html;
using System.Gadgets;
using Flickr;
using System.Diagnostics;

namespace Interestingness {

    public class GadgetScriptlet {

        private Gallery _gallery;

        private int _timerID;
        private bool _flyoutVisible;

        private GadgetScriptlet() {
            Type.SetField(Gadget.Document.ParentWindow, "Scriptlet", this);

            Gadget.OnDock = OnDock;
            Gadget.OnUndock = OnUndock;

            Gadget.Flyout.File = "Flyout.htm";
            Gadget.Flyout.OnShow = OnFlyoutShow;
            Gadget.Flyout.OnHide = OnFlyoutHide;

            UpdateDockedState();

            Gadget.SettingsUI = "Settings.htm";

            _gallery = new Gallery();
            _gallery.PhotoChanged += OnGalleryPhotoChanged;

            _timerID = Window.SetInterval(OnTimer, 4000);
            Script.Literal("{0}.attachEvent('onclick', {1})", Gadget.Document.Body, (Action)OnThumbnailClick);
        }

        public static GadgetScriptlet Current {
            get {
                return (GadgetScriptlet)Type.GetField(Gadget.Document.ParentWindow, "Scriptlet");
            }
        }

        public Gallery Gallery {
            get {
                return _gallery;
            }
        }

        public static void Main(Dictionary arguments) {
            GadgetScriptlet scriptlet = new GadgetScriptlet();
        }

        private void OnDock() {
            UpdateDockedState();
        }

        private void OnFlyoutHide() {
            _flyoutVisible = false;
        }

        private void OnFlyoutShow() {
            _flyoutVisible = true;

            Photo selectedPhoto = _gallery.SelectedPhoto;
            int width = Number.ParseInt(selectedPhoto.width_m);
            int height = Number.ParseInt(selectedPhoto.height_m);

            DocumentInstance flyoutDocument = Gadget.Flyout.Document;
            flyoutDocument.Body.Style.Width = (width + 8) + "px";
            flyoutDocument.Body.Style.Height = (height + 8) + "px";

            ImageElement photoImage = (ImageElement)flyoutDocument.GetElementById("photoImage");
            photoImage.Width = width;
            photoImage.Height = height;
            photoImage.Src = selectedPhoto.url_m;
        }

        private void OnGalleryPhotoChanged(object sender, EventArgs e) {
            Photo photo = _gallery.SelectedPhoto;
            if (photo != null) {
                ImageElement thumbnail = (ImageElement)Gadget.Document.GetElementById("thumbnail");
                thumbnail.Src = photo.url_sq;
                thumbnail.Title = photo.title;
            }
        }

        private void OnTimer() {
            if (_flyoutVisible) {
                return;
            }
            _gallery.NextPhoto();
        }

        private void OnThumbnailClick() {
            if (_gallery.SelectedPhoto != null) {
                Gadget.Flyout.Show = true;
            }
        }

        private void OnUndock() {
            UpdateDockedState();
        }

        private void UpdateDockedState() {
            Gadget.Document.Body.ClassName = Gadget.Docked ? "docked" : "undocked";
        }
    }
}
