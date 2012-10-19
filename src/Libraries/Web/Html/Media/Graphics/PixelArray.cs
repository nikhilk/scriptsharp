// PixelArray.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Graphics {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class PixelArray {

        private PixelArray() {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptField]
        public object this[int index] {
            get {
                return null;
            }
            set {
            }
        }
    }
}
