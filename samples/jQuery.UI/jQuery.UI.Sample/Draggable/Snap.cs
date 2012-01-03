// Snap.cs
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
    internal static class Snap
    {
        static Snap()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableSnap1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("snap", true));

                jQuery.Select("#draggableSnap2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("snap", ".ui-widget-header"));

                jQuery.Select("#draggableSnap3")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("snap", ".ui-widget-header"
                                                     , "snapMode", "outer"));

                jQuery.Select("#draggableSnap4")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("grid", new int[] { 20, 20 }));

                jQuery.Select("#draggableSnap5")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("grid", new int[] { 80, 80 }));
            });
        }
    }
}
