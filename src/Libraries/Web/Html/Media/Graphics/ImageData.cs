// ImageData.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Media.Graphics {

    [IgnoreNamespace]
    [Imported]
    public sealed class ImageData {

        private ImageData() {
        }

        [IntrinsicProperty]
        public PixelArray Data {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int Height {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public int Width {
            get {
                return 0;
            }
        }
    }
}
