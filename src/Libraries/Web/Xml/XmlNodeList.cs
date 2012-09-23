// XmlNodeList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class XmlNodeList : IEnumerable {

        internal XmlNodeList() {
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

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }
}
