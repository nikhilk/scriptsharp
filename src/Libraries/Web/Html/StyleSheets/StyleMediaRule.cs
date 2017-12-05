// StyleMediaRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StyleMediaRule : StyleRule {

        private StyleMediaRule() {
        }

        [ScriptField]
        public StyleMediaList Media {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptName("cssRules")]
        public StyleRuleList StyleRules {
            get {
                return null;
            }
        }

        public void DeleteRule(int index) {
        }

        public int InsertRule(string rule, int index) {
            return 0;
        }
    }
}
