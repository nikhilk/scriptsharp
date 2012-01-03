// AcceptedElements.cs
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
    internal static class AcceptedElements
    {
        static AcceptedElements()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableAcceptedElements, #draggable-nonvalid")
                   .Plugin<DraggableObject>()
                   .Draggable();

                jQuery.Select("#droppableAcceptedElements")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("accept", "#draggableAcceptedElements"
                                                   , "activeClass", "ui-state-hover"
                                                   , "hoverClass", "ui-state-active"                        
                                                   , "drop", new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui)
                                                   {
                                                        jQuery.This
                                                              .AddClass("ui-state-highlight")
                                                              .Find("p")
                                                              .Html("Dropped!");
                                                   })));
            });
        }
    }
}
