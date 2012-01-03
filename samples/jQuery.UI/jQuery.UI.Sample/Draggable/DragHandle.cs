// DragHandle.cs
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
    internal static class DragHandle
    {
        static DragHandle()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableHandle1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("handle", "p"));

                jQuery.Select("#draggableHandle2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("cancel", "p.ui-widget-header"));

                ((jQueryObjectUI)jQuery.Select("div, p")).DisableSelection();
            });
        }
    }
}
