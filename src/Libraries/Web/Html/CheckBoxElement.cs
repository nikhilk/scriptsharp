// CheckBoxElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class CheckBoxElement : InputElement {

        internal CheckBoxElement() {
        }

        [ScriptField]
        public bool Checked {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public bool DefaultChecked {
            get {
                return false;
            }
        }
    }
}
