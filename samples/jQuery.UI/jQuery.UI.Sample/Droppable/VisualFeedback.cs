// VisualFeedback.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Droppable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using jQueryApi;
using jQueryApi.UI;

namespace Sample.Droppable
{
    internal static class VisualFeedback
    {
        static VisualFeedback()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableVisualFeedback1, #draggableVisualFeedback2")
                    .Plugin<DraggableObject>()
                    .Draggable();

                DroppableEventHandler drop 
                    = new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui) 
                    {
                        jQuery.This
                                .AddClass("ui-state-highlight")
                                .Find("p")
                                .Html("Dropped!");
                    });

                jQuery.Select("#droppableVisualFeedback1")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("hoverClass", "ui-state-active"
                                                   , "drop", drop));

                jQuery.Select("#droppableVisualFeedback2")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("accept", "#draggableVisualFeedback2"
                                                   , "activeClass", "ui-state-hover"
                                                   , "drop", drop));
            });
        }
    }
}
