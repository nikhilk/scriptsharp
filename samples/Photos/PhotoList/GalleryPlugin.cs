// GalleryPlugin.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;
using jQueryApi.Templating;
using Flickr.FlickrClient;

[ScriptExtension("$.fn")]
public static class GalleryPlugin {

    public static jQueryObject Gallery(GalleryPluginOptions customOptions) {
        GalleryPluginOptions defaultOptions =
            new GalleryPluginOptions("count", 10,
                                     "photoService", new FlickrService());
        GalleryPluginOptions options =
            (GalleryPluginOptions)jQuery.Extend(new Dictionary<string, object>(), defaultOptions, customOptions);

        return jQuery.Current.Each(delegate(int i, Element element) {
            jQueryObject thumbnailList = jQuery.Select("#" + options.thumbsListID);
            jQueryObject photoPanel = jQuery.Select("#" + options.photoPanelID);

            options.photoService.SearchPhotos(options.tags, options.count, delegate(List<PhotoResult> photos) {
                if ((photos == null) || (photos.Count == 0)) {
                    return;
                }

                thumbnailList.Empty();
                jQuery.Select("#" + options.thumbnailTemplateID).Plugin<jQueryTemplateObject>().
                       RenderTemplate(photos).
                       CSS("opacity", "0.5").
                       AppendTo(thumbnailList).
                       MouseEnter(delegate(jQueryEvent e) {
                           jQuery.FromElement(e.CurrentTarget).FadeTo(250, 1.0f, delegate() {
                               jQuery.This.CSS("opacity", "1");
                           });
                       })
                       .MouseLeave(delegate(jQueryEvent e) {
                           jQuery.FromElement(e.CurrentTarget).FadeTo(250, 0.5f, delegate() {
                               jQuery.This.CSS("opacity", "0.5");
                           });
                       })
                       .Click(delegate(jQueryEvent e) {
                           PhotoResult photo = (PhotoResult)jQueryTemplating.GetTemplateInstance(e.CurrentTarget).Data;

                           jQueryTemplate photoTemplate = jQueryTemplating.CreateTemplate(jQuery.Select("#" + options.photoTemplateID));
                           photoPanel.FadeOut(EffectDuration.Slow, delegate() {
                               jQuery.This.Empty().CSS("display", "").
                                           Append(jQueryTemplating.RenderTemplate(photoTemplate, photo)).
                                           FadeIn(EffectDuration.Slow);
                           });
                       }).
                       Eq(0).Click();
            });

            return false;
        });
    }
}

[ScriptImport]
[ScriptName("Object")]
public sealed class GalleryPluginOptions {
    public string tags;
    public int count;
    public string thumbsListID;
    public string photoPanelID;
    public string thumbnailTemplateID;
    public string photoTemplateID;
    public IFlickrService photoService;

    public GalleryPluginOptions() {
    }

    public GalleryPluginOptions(params object[] nameValuePairs) {
    }
}

[ScriptImport]
public sealed class GalleryObject : jQueryObject {

    public jQueryObject Gallery() {
        return null;
    }

    public jQueryObject Gallery(GalleryPluginOptions options) {
        return null;
    }
}
