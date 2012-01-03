// PhotoManager.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Droppable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Collections;
using System.Html;
using jQueryApi;
using jQueryApi.UI;

namespace Sample.Droppable
{
    internal static class PhotoManager
    {
        static PhotoManager()
        {
            jQuery.OnDocumentReady(delegate()
            {
                // let the gallery items be draggable
                jQuery.Select("li", jQuery.Select("#gallery"))
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions(
                            "cancel", "a.ui-icon", // clicking an icon won't initiate dragging
                            "revert", "invalid", // when not dropped, the item will revert back to its initial position
                            "containment", jQuery.Select("#demo-frame").Length > 0 ? "#demo-frame" : "document", // stick to demo-frame if present
                            "helper", "clone",
                            "cursor", "move"
                        ));

                // let the trash be droppable, accepting the gallery items
                jQuery.Select("#trash")
                     .Plugin<DroppableObject>()
                     .Droppable(new DroppableOptions(
                        "accept", "#gallery > li",
                        "activeClass", "ui-state-highlight",
                        "drop", new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui)
                        {
                            DeleteImage(ui.Draggable);
                        })));

                // let the gallery be droppable as well, accepting items from the trash
                jQuery.Select("#gallery")
                      .Plugin<DroppableObject>()
                      .Droppable(new DroppableOptions(
                        "accept", "#trash li",
                        "activeClass", "custom-state-active",
                        "drop", new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui)
                        {
                            RecycleImage(ui.Draggable);
                        })));


                // resolve the icons behavior with event delegation
                jQuery.Select("ul.gallery > li")
                      .Click(delegate(jQueryEvent e)
                      {
                          jQueryObject item = jQuery.This;
                          jQueryObject target = jQuery.FromElement(e.Target);

                          if (target.Is("a.ui-icon-trash"))
                          {
                              DeleteImage(item);
                          }
                          else if (target.Is("a.ui-icon-zoomin"))
                          {
                              ViewLargerImage(target);
                          }
                          else if (target.Is("a.ui-icon-refresh"))
                          {
                              RecycleImage(item);
                          }

                          e.PreventDefault();
                          e.StopPropagation();
                      });
            });
        }

        // image deletion function
        static void DeleteImage(jQueryObject item)
        {
            string recycle_icon = "<a href='link/to/recycle/script/when/we/have/js/off' title='Recycle this image' class='ui-icon ui-icon-refresh'>Recycle image</a>";

            item.FadeOut(EffectDuration.Slow, delegate()
            {
                jQueryObject list = jQuery.Select("ul", jQuery.Select("#trash")).Length > 0 ?
                                    jQuery.Select("ul", jQuery.Select("#trash")) :
                                    jQuery.Select("<ul class='gallery ui-helper-reset'/>").AppendTo("#trash");

                item.Find("a.ui-icon-trash").Remove();
                item.Append(recycle_icon).AppendTo(list).FadeIn(EffectDuration.Slow, delegate()
                {
                    item.Animate(new Dictionary("width", "48px"))
                        .Find("img")
                        .Animate(new Dictionary("height", "36px"));
                });
            });
        }

        // image recycle function
        static void RecycleImage(jQueryObject item)
        {
            string trash_icon = "<a href='link/to/trash/script/when/we/have/js/off' title='Delete this image' class='ui-icon ui-icon-trash'>Delete image</a>";

            item.FadeOut(EffectDuration.Slow, delegate()
            {
                item.Find("a.ui-icon-refresh")
                    .Remove()
                    .End()
                    .CSS("width", "96px")
                    .Append(trash_icon)
                    .Find("img")
                    .CSS("height", "72px")
                    .End()
                    .AppendTo("#gallery")
                    .FadeIn();
            });
        }

        // image preview function, demonstrating the ui.dialog used as a modal window
        static void ViewLargerImage(jQueryObject link)
        {
            string src = link.GetAttribute("href");
            string title = link.Siblings("img").GetAttribute("alt");
            jQueryObject modal = jQuery.Select("img[src$='" + src + "']");

            if (modal.Length > 0)
            {
                modal.Plugin<DialogObject>()
                     .Dialog(DialogMethod.Open);
            }
            else
            {
                jQueryObject img
                    = jQuery.FromHtml("<img alt='" + title + "' width='384' height='288' style='display: none; padding: 8px;' />")
                            .Attribute("src", src).AppendTo("body");

                img.Plugin<DialogObject>()
                   .Dialog(new DialogOptions("title", title,
                                            "width", 400,
                                            "modal", true
                ));
            }
        }
    }
}
