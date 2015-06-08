// ScriptElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class ScriptElement : Element {

        private ScriptElement() {
        }

        [ScriptField]
        public string Src {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Type {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string ReadyState {
            get {
                return null;
            }
            set {
            }
        }
    }
}
