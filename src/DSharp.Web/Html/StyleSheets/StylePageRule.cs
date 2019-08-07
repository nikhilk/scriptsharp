// StylePageRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StylePageRule : StyleRule {

        private StylePageRule() {
        }

        [ScriptField]
        public string SelectorText {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Style Style {
            get {
                return null;
            }
        }
    }
}
