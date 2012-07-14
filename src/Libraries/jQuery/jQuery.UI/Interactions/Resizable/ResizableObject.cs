// ResizableObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Interactions {

    /// <summary>
    /// Change the size of an element using the mouse
    /// </summary>
    /// <remarks>
    /// <para>The jQuery UI Resizable plugin makes selected elements resizable (meaning they have draggable resize handles). You can specify one or more handles as well as min and max width and height.</para><para>All callbacks (start,stop,resize) receive two arguments: The original browser event and a prepared ui object.</para><para>This interaction requires some functional CSS, otherwise it won't work. If you build a custom theme, use the interaction's specific CSS file as a starting point.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class ResizableObject : WidgetObject {

        private ResizableObject() {
        }

        [ScriptName("resizable")]
        public ResizableObject Resizable() {
            return null;
        }

        [ScriptName("resizable")]
        public ResizableObject Resizable(ResizableOptions options) {
            return null;
        }
    }
}
