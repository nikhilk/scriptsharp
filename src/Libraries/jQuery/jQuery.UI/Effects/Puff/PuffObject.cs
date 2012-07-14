// PuffObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Creates a puff effect by scaling the element up and hiding it at the same time.
    /// </summary>
    /// <remarks>
    /// This is the only effect without a separate file, it shares a file with the scale effect.
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class PuffObject : EffectObject {

        private PuffObject() {
        }

        [ScriptName("puff")]
        public PuffObject Puff() {
            return null;
        }

        [ScriptName("puff")]
        public PuffObject Puff(PuffOptions options) {
            return null;
        }
    }
}
