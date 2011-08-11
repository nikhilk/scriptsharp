// PhotoGridPage.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;
using jQueryApi.Templating;
using jQueryApi.Isotope;
using jQueryApi.LightBox;
using PhotoGrid.Flickr;

namespace PhotoGrid {

    [GlobalMethods]
    internal static class PhotoGridPage {
    
        static PhotoGridPage() {
            jQuery.OnDocumentReady(delegate() {
                string apiKey = (string)jQuery.FromElement(Document.Body).GetDataValue("flickrKey");
                FlickrService flickrService = new FlickrService(apiKey);

                jQuery.Select("#searchButton").Click(delegate(jQueryEvent e) {
                    string tags = jQuery.Select("#tagsTextBox").GetValue();

                    flickrService.SearchPhotos(tags, 20).Done(
                        delegate(IEnumerable<Photo> photos) {
                            jQueryObject thumbnailList = jQuery.Select("#thumbsList");
                            thumbnailList.Empty();

                            if (photos == null) {
                                return;
                            }

                            jQuery.Select("#thumbnailTemplate").Plugin<jQueryTemplateObject>().
                                RenderTemplate(photos).
                                AppendTo(thumbnailList);

                            thumbnailList.
                                Plugin<jQueryIsotopeObject>().Isotope(new IsotopeOptions("layoutMode", IsotopeLayout.Masonry)).
                                Find("a").
                                Plugin<jQueryLightBoxObject>().LightBox();

                            thumbnailList.Find("li").
                                MouseOver(delegate(jQueryEvent e2) {
                                    jQuery.This.CSS("box-shadow", "0 0 15px #888");
                                }).
                                MouseOut(delegate(jQueryEvent e2) {
                                    jQuery.This.CSS("box-shadow", "");
                                });
                        });

                    jQuery.FromElement(Document.Body).Focus();
                    e.PreventDefault();
                });
            });
        }
    }
}
