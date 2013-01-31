// CSSStyleRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.CSS {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class CSSStyleRule : CSSRule {

        private CSSStyleRule() {
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
