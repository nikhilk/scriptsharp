// AutoScroll.cs
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
    internal static class AutoScroll
    {
        static AutoScroll()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableAutoScroll1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("scroll", true));

                jQuery.Select("#draggableAutoScroll2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions( "scroll", true
                                                     , "scrollSensitivity", 100));

                jQuery.Select("#draggableAutoScroll3")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions( "snap", true
                                                     , "scrollSpeed", 100));
            });
        }
    }
}
