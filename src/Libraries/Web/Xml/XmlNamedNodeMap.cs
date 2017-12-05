// XmlNamedNodeMap.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("NamedNodeMap")]
    public sealed class XmlNamedNodeMap : IEnumerable {

        internal XmlNamedNodeMap() {
        }

        [ScriptField]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [ScriptField]
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
