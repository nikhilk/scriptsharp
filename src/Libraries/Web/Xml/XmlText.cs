// XmlText.cs
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
    public sealed class XmlText : XmlNode {

        internal XmlText() {
        }

        [IntrinsicProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public string Data {
            get {
                return null;
            }
            set {
            }
        }

        public XmlText SplitText(int offset) {
            return null;
        }
    }
}
