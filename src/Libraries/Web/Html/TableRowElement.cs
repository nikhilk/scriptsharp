// TableRowElement.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
