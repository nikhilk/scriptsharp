// ElementAttribute.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class ElementAttribute {

        internal ElementAttribute() {
        }

        [IntrinsicProperty]
        public string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool Specified {
            get {
                return false;
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
