// TableElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class TableElement : Element {

        private TableElement() {
        }

        [ScriptField]
        public ElementCollection Cells {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementCollection Rows {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementCollection tBodies {
            get {
                return null;
            }
        }

        [ScriptField]
        public Element tFoot {
            get {
                return null;
            }
        }

        [ScriptField]
        public ElementCollection tHead {
            get {
                return null;
            }
        }

        public void DeleteRow() {
        }

        public void DeleteRow(int index) {
        }

        public TableRowElement InsertRow() {
            return null;
        }

        public TableRowElement InsertRow(int index) {
            return null;
        }
    }
}
