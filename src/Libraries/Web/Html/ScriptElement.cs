// ScriptElement.cs
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
    public sealed class ScriptElement : Element {

        private ScriptElement() {
        }

        [IntrinsicProperty]
        public string Src {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Type {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string ReadyState {
            get {
                return null;
            }
            set {
            }
        }
    }
}
