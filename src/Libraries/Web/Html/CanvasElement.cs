// CanvasElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html.Media.Graphics;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class CanvasElement : Element {

        private CanvasElement() {
        }

        [ScriptField]
        public int Height {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
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
