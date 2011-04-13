// FormElement.cs
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
    public sealed class FormElement : Element {

        internal FormElement() {
        }

        [IntrinsicProperty]
        public string AcceptCharset {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Action {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public Element[] Elements {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string EncType {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Encoding {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string Name {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Method {
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

        public void Reset() {
        }

        public void Submit() {
        }
    }
}
