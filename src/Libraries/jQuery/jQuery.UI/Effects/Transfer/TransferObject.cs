// TransferObject.cs
// Script#/Libraries/jQuery/UI
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace jQueryApi.UI.Effects {

    /// <summary>
    /// Transfers the outline of an element to another element
    /// </summary>
    /// <remarks>
    /// Very useful when trying to visualize interaction between two elements.<para>The transfer element iself has the class name "ui-effects-transfer", and needs to be styled by you, for example by adding a background or border.</para>
    /// </remarks>
    [Imported]
    [IgnoreNamespace]
    public sealed class TransferObject : EffectObject {

        private TransferObject() {
        }

        [ScriptName("transfer")]
        public TransferObject Transfer() {
            return null;
        }

        [ScriptName("transfer")]
        public TransferObject Transfer(TransferOptions options) {
            return null;
        }
    }
}
