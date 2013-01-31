// StyleSheetList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StyleSheetList {

        private StyleSheetList() {
        }

        [ScriptField]
        public long Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public StyleSheet this[int index] {
            get {
                return null;
            }
        }
    }
}
