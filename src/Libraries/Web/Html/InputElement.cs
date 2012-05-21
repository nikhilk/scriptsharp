// InputElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public class InputElement : Element {

        protected internal InputElement() {
        }

        [IntrinsicProperty]
        public string DefaultValue {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public FormElement Form {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string Name {
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
        public string Value {
            get {
                return null;
            }
            set {
            }
        }

        public void Select() {
        }
    }
}
