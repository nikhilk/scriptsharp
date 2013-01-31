// CSSImportRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.CSS {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class CSSImportRule : CSSRule {

        private CSSImportRule() {
        }

        [ScriptField]
        public string Href {
            get {
                return null;
            }
        }

        [ScriptField]
        public MediaList Media {
            get {
                return null;
            }
        }

        [ScriptField]
        public StyleSheet StyleSheet {
            get {
                return null;
            }
        }
    }
}
