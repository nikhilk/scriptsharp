// TextAreaElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class TextAreaElement : InputElement {

        private TextAreaElement() {
        }

        [ScriptField]
        public int Cols {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public bool ReadOnly {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public int Rows {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
