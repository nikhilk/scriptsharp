// StyleRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public abstract class StyleRule {

        internal StyleRule() {
        }

        [ScriptField]
        [ScriptName("cssText")]
        public string CSSText {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public StyleRule ParentRule {
            get {
                return null;
            }
        }

        [ScriptField]
        public StyleSheet ParentStyleSheet {
            get {
                return null;
            }
        }

        [ScriptField]
        public StyleRuleType Type {
            get {
                return StyleRuleType.Unknown;
            }
        }
    }
}
