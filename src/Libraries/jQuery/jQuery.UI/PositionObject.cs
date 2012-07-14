// PositionObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI {

    /// <summary>
    /// Place an element relative to another
    /// </summary>
    /// <remarks>
    /// <para>Utility script for positioning any widget relative to the window, document, a particular element, or the cursor/mouse.</para><para><em>Note: jQuery UI does not support positioning hidden elements.</em></para><para>This is a standalone jQuery plugin and has no dependencies on other jQuery UI components.</para><para>This plugin extends jQuery's built-in position getter method. If you forget to include this plugin, code calling position() won't fail directly, as the method still exists. But it'll just retrieve the position instead of setting it.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class PositionObject : jQueryUIObject {

        private PositionObject() {
        }

        [ScriptName("position")]
        public new PositionObject Position() {
            return null;
        }

        [ScriptName("position")]
        public PositionObject Position(PositionOptions options) {
            return null;
        }
    }
}
