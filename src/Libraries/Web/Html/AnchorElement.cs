// AnchorElement.cs
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
    public sealed class AnchorElement : Element {

        private AnchorElement() {
        }

        [IntrinsicProperty]
        public string Href {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Rel {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Target {
            get {
                return null;
            }
            set {
            }
        }
        
        [IntrinsicProperty]
        public string Download {
            get {
                return null;
            }
            set {
            }
        }
    }
}
