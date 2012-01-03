// VisualFeedback.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Draggable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using jQueryApi;
using jQueryApi.UI;
using System.Collections;
using System;

namespace Sample.Draggable
{
    internal static class VisualFeedback
    {
        static VisualFeedback()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableVisual1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("helper", "original"));

                jQuery.Select("#draggableVisual2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("opacity", 0.7f
                                                     , "helper", "clone"));


                DraggableOptions options = new DraggableOptions();
                options.Cursor = "move";
                options.CursorAt = new Dictionary("top", -12, "left", -20);
                options.Helper = new Func<jQueryEvent, jQueryObject>(delegate(jQueryEvent e)
                {
                    return jQuery.FromHtml("<div class='ui-widget-header'>I'm a custom helper</div>");
                });

                jQuery.Select("#draggableVisual3")
                      .Plugin<DraggableObject>()
                      .Draggable(options);

                jQuery.Select("#draggableVisualSet div")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("stack", "#draggableVisualSet div"));
            });
        }
    }
}
