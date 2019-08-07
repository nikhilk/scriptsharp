// ElementAttribute.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class ElementAttribute {

        internal ElementAttribute() {
        }

        [ScriptField]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Specified {
            get {
                return false;
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
