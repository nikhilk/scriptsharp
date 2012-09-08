// PhotoTilesPage.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;
using jQueryApi.Templating;
using jQueryApi.Gridster;
using jQueryApi.LightBox;
using Photos;

namespace PhotoGrid {

    [GlobalMethods]
    internal static class PhotoTilesPage {

        static PhotoTilesPage() {
            jQuery.OnDocumentReady(delegate() {
                string apiKey = (string)jQuery.FromElement(Document.Body).GetDataValue("flickrKey");
                IPhotoService flickrService = new FlickrPhotoService();

                jQuery.Select("#searchButton").Click(delegate(jQueryEvent e) {
                    string tags = jQuery.Select("#tagsTextBox").GetValue();

                    flickrService.SearchPhotos(tags, 20).Done(
                        delegate(IEnumerable<Photo> photos) {
                            jQueryObject thumbnailList = jQuery.Select("#thumbsList");
                            thumbnailList.Empty();

                            if (photos == null) {
                                return;
                            }

                            int photoIndex = 0;
                            foreach (Photo photo in photos) {
                                if (photoIndex % 6 == 0) {
                                    jQuery.Select("#bigThumbnailTemplate").Plugin<jQueryTemplateObject>()
                                        .RenderTemplate(photo)
                                        .AppendTo(thumbnailList);
                                }
                                else if ((photoIndex % 3 == 0) || (photo.imageWidth == photo.imageHeight)) {
                                    jQuery.Select("#sqThumbnailTemplate").Plugin<jQueryTemplateObject>()
                                        .RenderTemplate(photo)
                                        .AppendTo(thumbnailList);
                                }
                                else if (photo.thumbnailWidth > photo.thumbnailHeight) {
                                    jQuery.Select("#horzThumbnailTemplate").Plugin<jQueryTemplateObject>()
                                        .RenderTemplate(photo)
                                        .AppendTo(thumbnailList);
                                }
                                else {
                                    jQuery.Select("#vertThumbnailTemplate").Plugin<jQueryTemplateObject>()
                                        .RenderTemplate(photo)
                                        .AppendTo(thumbnailList);
                                }

                                photoIndex++;
                            }

                            GridsterOptions gridOptions = new GridsterOptions();
                            gridOptions.Margins = new int[] { 10, 10 };
                            gridOptions.BaseDimensions = new int[] { 140, 140 };

                            thumbnailList.Plugin<jQueryGridsterObject>().Gridster(gridOptions)
                                .Find("a")
                                .Plugin<jQueryLightBoxObject>().LightBox();

                            GridsterObject gridster =
                                (GridsterObject)thumbnailList.GetDataValue("gridster");
                            gridster.DisableDragging();
                        });

                    jQuery.FromElement(Document.Body).Focus();
                    e.PreventDefault();
                });
            });
        }
    }
}
