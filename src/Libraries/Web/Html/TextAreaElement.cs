// TextAreaElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
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
