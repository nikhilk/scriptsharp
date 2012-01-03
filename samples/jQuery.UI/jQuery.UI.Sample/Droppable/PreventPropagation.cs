// PreventPropagation.cs
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
    internal static class PreventPropagation
    {
        static PreventPropagation()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggablePreventPropagation")
                    .Plugin<DraggableObject>()
                    .Draggable();

                DroppableEventHandler drop 
                    = new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui)
                    {
                        jQuery.This
                                .AddClass("ui-state-highlight")
                                .Find("> p")
                                .Html("Dropped!");
                    });

                jQuery.Select("#droppablePreventPropagation1, #droppablePreventPropagation1-inner")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions( "activeClass", "ui-state-hover"
                                                   , "hoverClass", "ui-state-active"
                                                   , "drop", drop));

                jQuery.Select("#droppablePreventPropagation2, #droppablePreventPropagation2-inner")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("activeClass", "ui-state-hover"
                                                   , "hoverClass", "ui-state-active"
                                                   , "greedy", true
                                                   , "drop", drop));
            });
        }
    }
}
