// CursorStyle.cs
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
    internal static class CursorStyle
    {
        static CursorStyle()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableCursor1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("cursor", "move"
                                                     , "top", 56, "left", 56 ));

                jQuery.Select("#draggableCursor2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("cursor", "crosshair"
                                                     , "top", -5, "left", -5));

                jQuery.Select("#draggableCursor3")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("bottom", 0));
            });
        }
    }
}
