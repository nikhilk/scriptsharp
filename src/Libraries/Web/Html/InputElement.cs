// InputElement.cs
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
    public class InputElement : Element {

        protected internal InputElement() {
        }

        [IntrinsicProperty]
        public FormElement Form {
            get {
                return null;
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
        public string Type {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public string Value {
            get {
                return null;
            }
            set {
            }
        }

        public void Select() {
        }
    }
}
