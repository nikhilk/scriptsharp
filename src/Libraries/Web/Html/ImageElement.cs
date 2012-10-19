// ImageElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Image")]
    public sealed class ImageElement : Element {

        public ImageElement() {
        }

        public ImageElement(int width) {
        }

        public ImageElement(int width, int height) {
        }

        [ScriptField]
        public string Alt {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public bool Complete {
            get {
                return false;
            }
        }

        [ScriptField]
        public string Src {
            get {
                return null;
            }
            set {
            }
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
        public int NaturalHeight {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptField]
        public int NaturalWidth {
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
    }
}
