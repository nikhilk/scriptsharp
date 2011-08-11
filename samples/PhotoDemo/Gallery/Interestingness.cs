// Interestingness.cs
//

using System;
using System.Collections;
using jQueryApi;
using jQueryApi.History;

namespace Gallery {

    public class Interestingness {

        private static string _currentTags;

        public static void Main(Dictionary args) {
            jQuery.Window.Bind("hashchange", delegate(jQueryEvent e) {
                string tags = (string)jQueryHistory.GetState("tags");
                if (tags != _currentTags) {
                    ShowPhotos(tags);
                }
            });

            jQuery.Select("#searchButton").Bind("click", delegate(jQueryEvent e) {
                string tags = jQuery.Select("#tagsTextBox").GetValue();
                ShowPhotos(tags);
            });
        }

        private static void ShowPhotos(string tags) {
            if (String.IsNullOrEmpty(tags)) {
                return;
            }

            _currentTags = tags;
            GalleryPluginOptions options =
                new GalleryPluginOptions("tags", tags,
                                         "thumbsListID", "thumbsList",
                                         "photoPanelID", "photoPanel",
                                         "thumbnailTemplateID", "thumbnailTemplate",
                                         "photoTemplateID", "photoTemplate");

            jQuery.Select("#gallery").Plugin<GalleryObject>().Gallery(options);
            jQueryHistory.PushState(new Dictionary("tags", tags));
        }
    }
}
