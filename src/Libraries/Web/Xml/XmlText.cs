// XmlText.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName(Object.NAME_DEFINITION)]
    public sealed class XmlText : XmlNode {

        internal XmlText() {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptField]
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