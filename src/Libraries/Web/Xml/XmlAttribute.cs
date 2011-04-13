// XmlAttribute.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public sealed class XmlAttribute : XmlNode {

        internal XmlAttribute() {
        }

        [IntrinsicProperty]
        public override string Name {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public bool Specified {
            get {
                return false;
            }
        }

        [IntrinsicProperty]
        public override string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
