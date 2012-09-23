// XmlNamedNodeMap.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class XmlNamedNodeMap : IEnumerable {

        internal XmlNamedNodeMap() {
        }

        [ScriptProperty]
        [ScriptName("length")]
        public int Count {
            get {
                return 0;
            }
        }

        [ScriptProperty]
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
