// DataTransfer.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class DataTransfer {

        private DataTransfer() {
        }

        [IntrinsicProperty]
        public DropEffect DropEffect {
            get {
                return DropEffect.None;
            }
            set {
            }
        }

        [IntrinsicProperty]
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
