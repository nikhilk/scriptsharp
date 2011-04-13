// IFrameElement.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
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
