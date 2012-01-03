// Revert.cs
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
    internal static class Revert
    {
        static Revert()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableRevert10")
                    .Plugin<DraggableObject>()
                    .Draggable(new DraggableOptions("revert", "valid"));

                jQuery.Select("#draggableRevert20")
                    .Plugin<DraggableObject>()
                    .Draggable(new DraggableOptions("revert", "invalid"));

                jQuery.Select("#droppableRevert10")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("activeClass", "ui-state-hover"
                                                   , "hoverClass", "ui-state-active"
                        , "drop"
                        , new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui) 
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
