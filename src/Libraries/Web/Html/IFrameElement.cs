// IFrameElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IFrameElement : Element {

        private IFrameElement() {
        }

        [ScriptField]
        public WindowInstance ContentWindow {
            get {
                return null;
            }
        }

        [ScriptField]
        public string FrameBorder {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string Scrolling {
            get {
                return null;
            }
            set {
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
    }
}
