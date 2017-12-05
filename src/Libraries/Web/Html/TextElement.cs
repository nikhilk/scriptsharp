// InputElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class TextElement : InputElement {

        internal TextElement() {
        }

        [ScriptField]
        public int MaxLength {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public bool ReadOnly {
            get {
                return false;
            }
            set {
            }
        }
    }
}
