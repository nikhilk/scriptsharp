// ElementAttribute.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class ElementAttribute {

        internal ElementAttribute() {
        }

        [ScriptProperty]
        public string Name {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public bool Specified {
            get {
                return false;
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
