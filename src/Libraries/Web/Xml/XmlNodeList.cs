// XmlNodeList.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public sealed class XmlNodeList : IEnumerable {

        internal XmlNodeList() {
        }

        [IntrinsicProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public XmlNode this[int index] {
            get {
                return null;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
