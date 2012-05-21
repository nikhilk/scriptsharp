// TableElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TableElement : Element {

        private TableElement() {
        }

        [IntrinsicProperty]
        public ElementCollection Cells {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public ElementCollection Rows {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public ElementCollection tBodies {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public Element tFoot {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
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
