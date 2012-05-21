// IFrameElement.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html {

    [IgnoreNamespace]
    [Imported]
    public sealed class IFrameElement : Element {

        private IFrameElement() {
        }

        [IntrinsicProperty]
        public WindowInstance ContentWindow {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public string FrameBorder {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Scrolling {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Src {
            get {
                return null;
            }
            set {
            }
        }
    }
}
