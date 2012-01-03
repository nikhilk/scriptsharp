// ConstrainMovement.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Draggable
// Copyright (c) Ivaylo Gochkov, 2012
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//
using System.Runtime.CompilerServices;
using jQueryApi;
using jQueryApi.UI;

namespace Sample.Draggable
{
    internal static class ConstrainMovement
    {
        static ConstrainMovement()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQuery.Select("#draggableConstrain1")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("axis", "y"));

                jQuery.Select("#draggableConstrain2")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("axis", "x"));

                jQuery.Select("#draggableConstrain3")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("containment", "#containment-wrapper"
                                                     , "scroll", false));

                jQuery.Select("#draggableConstrain4")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("containment", "#demo-frame"));

                jQuery.Select("#draggableConstrain5")
                      .Plugin<DraggableObject>()
                      .Draggable(new DraggableOptions("containment", "parent"));
            });
        }
    }
}
