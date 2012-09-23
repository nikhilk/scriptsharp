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

        [ScriptProperty]
        public WindowInstance ContentWindow {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public string FrameBorder {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptProperty]
        public string Scrolling {
            get {
                return null;
            }
            set {
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
    }
}
