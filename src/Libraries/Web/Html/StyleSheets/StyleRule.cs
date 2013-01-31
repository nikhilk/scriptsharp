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

        public const ushort UNKNOWN_RULE = 0;
        public const ushort STYLE_RULE = 1;
        public const ushort CHARSET_RULE = 2;
        public const ushort IMPORT_RULE = 3;
        public const ushort MEDIA_RULE = 4;
        public const ushort FONT_FACE_RULE = 5;
        public const ushort PAGE_RULE = 6;

        protected StyleRule() {
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
        public StyleSheet ParentStyleSheet {
            get {
                return null;
            }
        }

        [ScriptField]
        public StyleRule ParentRule {
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
