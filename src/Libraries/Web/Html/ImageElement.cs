// ImageElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Image")]
    public sealed class ImageElement : Element {

        public ImageElement() {
        }

        public ImageElement(int width) {
        }

        public ImageElement(int width, int height) {
        }

        [ScriptProperty]
        public string Alt {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public bool Complete {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public string Src {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Height {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public int NaturalHeight {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public int NaturalWidth {
            get {
                return 0;
            }
            set {
            }
        }

        [ScriptProperty]
        public int Width {
            get {
                return 0;
            }
            set {
            }
        }
    }
}
