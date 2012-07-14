// DraggableObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Allow mouse interactions with elements, moving them around
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Draggable plugin makes selected elements draggable by mouse.</para><para>Draggable elements gets a class of <code>ui-draggable</code>. During drag the element also gets a class of <code>ui-draggable-dragging</code>. If you want not just drag, but drag-and-drop, see the jQuery UI Droppable plugin, which provides a drop target for draggables.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class DraggableObject : WidgetObject {

        private DraggableObject() {
        }

        [ScriptName("draggable")]
        public DraggableObject Draggable() {
            return null;
        }

        [ScriptName("draggable")]
        public DraggableObject Draggable(DraggableOptions options) {
            return null;
        }
    }
}
