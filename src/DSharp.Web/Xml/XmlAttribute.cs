// XmlAttribute.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Attr")]
    public sealed class XmlAttribute : XmlNode {

        internal XmlAttribute() {
        }

        [ScriptField]
        public override string Name {
            get {
                return null;
            }
        }

        [ScriptField]
        public bool Specified {
            get {
                return false;
            }
        }

        [ScriptField]
        public override string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
