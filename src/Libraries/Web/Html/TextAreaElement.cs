// TextAreaElement.cs
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
    public sealed class TextAreaElement : InputElement {

        private TextAreaElement() {
        }

        [IntrinsicProperty]
        public int Cols {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public bool ReadOnly {
            get {
                return false;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Rows {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
