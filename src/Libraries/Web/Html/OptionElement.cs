// OptionElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class OptionElement : Element {

        private OptionElement() {
        }

        [ScriptField]
        public FormElement Form {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Selected {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public string Text {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
