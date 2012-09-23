// XmlText.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public sealed class XmlText : XmlNode {

        internal XmlText() {
        }

        [ScriptProperty]
        public int Length {
            get {
                return 0;
            }
        }

        [ScriptProperty]
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
