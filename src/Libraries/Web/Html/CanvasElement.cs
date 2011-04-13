// CanvasElement.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.Media.Graphics;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class CanvasElement : Element {

        private CanvasElement() {
        }

        [IntrinsicProperty]
        public int Height {
            get {
                return 0;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Width {
            get {
                return 0;
            }
            set {
            }
        }

        public CanvasContext GetContext(string contextID) {
            return null;
        }

        public CanvasContext GetContext(Rendering renderingType) {
            return null;
        }

        [ScriptName("toDataURL")]
        public string GetDataUrl() {
            return null;
        }

        [ScriptName("toDataURL")]
        public string GetDataUrl(string type) {
            return null;
        }

        [ScriptName("toDataURL")]
        public string GetDataUrl(string type, params object[] typeArguments) {
            return null;
        }
    }
}
