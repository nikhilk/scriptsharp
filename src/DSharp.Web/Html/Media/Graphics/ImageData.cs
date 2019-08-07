// ImageData.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Graphics {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class ImageData {

        private ImageData() {
        }

        [ScriptField]
        public PixelArray Data {
            get {
                return null;
            }
        }

        [ScriptField]
        public int Height {
            get {
                return 0;
            }
        }

        [ScriptField]
        public int Width {
            get {
                return 0;
            }
        }
    }
}
