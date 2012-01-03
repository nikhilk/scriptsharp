// DelayStart.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Draggable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using jQueryApi;
using jQueryApi.UI;
using System.Html;

namespace Sample.Draggable
{
    internal static class DelayStart
    {
        static DelayStart()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableDelay")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("distance", 20));

                jQuery.Select("#draggableDelay2")
                              .Plugin<DraggableObject>()
                              .Draggable(new DraggableOptions("delay", 1000));

                ((jQueryObjectUI)jQuery.Select(".ui-draggable")).DisableSelection();
            });
        }
    }
}
