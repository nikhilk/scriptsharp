// DataTransfer.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DataTransfer {

        private DataTransfer() {
        }

        [ScriptField]
        public DropEffect DropEffect {
            get {
                return DropEffect.None;
            }
            set {
            }
        }

        [ScriptField]
        public DropEffects EffectAllowed {
            get {
                return DropEffects.None;
            }
            set {
            }
        }

        public void ClearData() {
        }

        public void ClearData(DataFormat format) {
        }

        public string GetData(DataFormat format) {
            return null;
        }

        public bool SetData(DataFormat format, string data) {
            return false;
        }
    }
}
