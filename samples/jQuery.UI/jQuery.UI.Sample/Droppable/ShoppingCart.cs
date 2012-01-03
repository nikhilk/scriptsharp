// ShoppingCart.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Droppable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using jQueryApi;
using jQueryApi.UI;
using System;

namespace Sample.Droppable
{
    internal static class ShoppingCart
    {
        static ShoppingCart()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#catalog")
                      .Plugin<AccordionObject>()
                      .Accordion();

                jQuery.Select("#catalog li")
                    .Plugin<DraggableObject>()
                    .Draggable(new DraggableOptions("appendTo", "body"
                                                   , "helper", "clone"));

                jQuery.Select("#cart ol")
                    .Plugin<DroppableObject>()
                    .Droppable(new DroppableOptions("activeClass", "ui-state-default"
                        , "hoverClass", "ui-state-hover"
                        , "accept", ":not(.ui-sortable-helper)"
                        , "drop"
                        , new DroppableEventHandler(delegate(jQueryEvent e, DroppableEventData ui)
                        {
                            jQuery.This.Find(".placeholder").Remove();
                            jQuery.FromHtml("<li></li>").Text(ui.Draggable.GetText()).AppendTo(jQuery.This);
                        })))
                    .Plugin<SortableObject>()
                    .Sortable(new SortableOptions("items", "li:not(.placeholder)"
                        , "sort"
                        , new Action(delegate()
                        {
                            // gets added unintentionally by droppable interacting with sortable
                            // using connectWithSortable fixes this, but doesn't allow you to customize active/hoverClass options
                            jQuery.This.RemoveClass("ui-state-default");
                        })));
            });
        }
    }
}
