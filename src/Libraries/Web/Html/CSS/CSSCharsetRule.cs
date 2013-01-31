// CSSCharsetRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.CSS {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class CSSCharsetRule : CSSRule {

        private CSSCharsetRule() {
        }

        [ScriptField]
        public string Encoding {
            get {
                return null;
            }
            set {
            }
        }
    }
}
