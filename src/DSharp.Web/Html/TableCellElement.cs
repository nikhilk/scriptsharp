// TableCellElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class TableCellElement : Element {

        private TableCellElement() {
        }

        [ScriptField]
        public int ColSpan {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public bool NoWrap {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public int RowSpan {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
