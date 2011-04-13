// CheckBoxElement.cs
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
    public class CheckBoxElement : InputElement {

        internal CheckBoxElement() {
        }

        [IntrinsicProperty]
        public bool Checked {
            get {
                return false;
            }
            set {
            }
        }
    }
}
