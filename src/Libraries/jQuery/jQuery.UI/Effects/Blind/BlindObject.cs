// BlindObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// The blind effect hides or shows an element by wrapping the element in a container, and "pulling the blinds"
    /// </summary>
    /// <remarks>
    /// The container has <code>overflow:hidden</code> applied, so height changes affect what's visible.
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class BlindObject : EffectObject {

        private BlindObject() {
        }

        [ScriptName("blind")]
        public BlindObject Blind() {
            return null;
        }

        [ScriptName("blind")]
        public BlindObject Blind(BlindOptions options) {
            return null;
        }
    }
}
