// StyleMediaList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Html.StyleSheets {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class StyleMediaList : IEnumerable {

        private StyleMediaList() {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public string MediaText {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string this[int index] {
            get {
                return null;
            }
        }

        public void AppendMedium(string newMedium) {
        }

        public void DeleteMedium(string oldMedium) {
        }

        public static implicit operator string[](StyleMediaList list) {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
