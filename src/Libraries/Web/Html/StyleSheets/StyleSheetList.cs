// StyleSheetList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StyleSheetList : IEnumerable {

        private StyleSheetList() {
        }

        [ScriptField]
        public int Length {
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

        public static implicit operator StyleSheet[](StyleSheetList list) {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
