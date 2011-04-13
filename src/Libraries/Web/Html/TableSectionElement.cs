// TableSectionElement.cs
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
    public sealed class TableSectionElement : Element {

        private TableSectionElement() {
        }

        [IntrinsicProperty]
        public ElementCollection Rows {
            get {
                return null;
            }
        }
    }
}
