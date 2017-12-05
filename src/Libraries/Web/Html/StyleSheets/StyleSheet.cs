// StyleSheet.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StyleSheet {

        private StyleSheet() {
        }

        [ScriptField]
        [ScriptName("cssRules")]
        public StyleRuleList StyleRules {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Disabled {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public string Href {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Id {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public StyleMediaList Media {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element OwnerNode {
            get {
                return null;
            }
        }

        [ScriptField]
        public StyleRule OwnerRule {
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
        public string Title {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Type {
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
