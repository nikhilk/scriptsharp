// CheckBoxElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public class CheckBoxElement : InputElement {

        internal CheckBoxElement() {
        }

        [ScriptProperty]
        public bool Checked {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool DefaultChecked {
            get {
                return false;
            }
        }
    }
}
