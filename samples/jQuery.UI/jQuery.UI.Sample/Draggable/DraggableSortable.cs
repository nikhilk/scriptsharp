// DraggableSortable.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Draggable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using jQueryApi;
using jQueryApi.UI;

namespace Sample.Draggable
{
    internal static class DraggableSortable
    {
        static DraggableSortable()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#sortable")
                    .Plugin<SortableObject>()
                    .Sortable(new SortableOptions("revert", true));

                jQuery.Select("#draggableSortable")
                    .Plugin<DraggableObject>()
                    .Draggable(new DraggableOptions( "connectToSortable", "#sortable"
                                                   , "helper", "clone"
                                                   , "revert", "invalid"));

                ((jQueryObjectUI)jQuery.Select("ul, li")).DisableSelection();
            });
        }
    }
}
