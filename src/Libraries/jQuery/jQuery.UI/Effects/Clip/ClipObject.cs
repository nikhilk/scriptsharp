// ClipObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// The clip effect will hide or show an element by clipping the element vertically or horizontally
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class ClipObject : EffectObject {

        private ClipObject() {
        }

        [ScriptName("clip")]
        public ClipObject Clip() {
            return null;
        }

        [ScriptName("clip")]
        public ClipObject Clip(ClipOptions options) {
            return null;
        }
    }
}
