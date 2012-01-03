// Default.cs
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
    internal static class Default
    {
        static Default()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#droppableDraggableDefault")
                    .Plugin<DraggableObject>()
                    .Draggable();

                jQuery.Select("#droppableDroppableDefault")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("drop"
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
