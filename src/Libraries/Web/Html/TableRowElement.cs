// TableRowElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class TableRowElement : Element {

        private TableRowElement() {
        }

        [IntrinsicProperty]
        public ElementCollection Cells {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int RowIndex {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int SectionRowIndex {
            get {
                return 0;
            }
        }

        public void DeleteCell() {
        }

        public void DeleteCell(int index) {
        }

        public TableCellElement InsertCell() {
            return null;
        }

        public TableCellElement InsertCell(int index) {
            return null;
        }
    }
}
