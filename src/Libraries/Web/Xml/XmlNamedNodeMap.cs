// XmlNamedNodeMap.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public sealed class XmlNamedNodeMap : IEnumerable {

        internal XmlNamedNodeMap() {
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

        public XmlNode GetNamedItem(string name) {
            return null;
        }

        public XmlNode RemoveNamedItem(string name) {
            return null;
        }

        public XmlNode SetNamedItem(XmlNode node) {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
