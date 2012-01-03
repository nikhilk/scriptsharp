// RevertPosition.cs
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
    internal static class RevertPosition
    {
        static RevertPosition()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableRevert1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("revert", true));

                jQuery.Select("#draggableRevert2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("revert", true
                                                     , "helper", "clone"));
            });
        }
    }
}
