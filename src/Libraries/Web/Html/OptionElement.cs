// OptionElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class OptionElement : Element {

        private OptionElement() {
        }

        [ScriptProperty]
        public FormElement Form {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public bool Selected {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Text {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
