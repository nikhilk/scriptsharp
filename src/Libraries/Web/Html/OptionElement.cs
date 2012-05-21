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

        [IntrinsicProperty]
        public FormElement Form {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool Selected {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Text {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
