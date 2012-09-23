// TextAreaElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class TextAreaElement : InputElement {

        private TextAreaElement() {
        }

        [ScriptProperty]
        public int Cols {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool ReadOnly {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Rows {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
