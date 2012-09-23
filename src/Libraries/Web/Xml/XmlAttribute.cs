// XmlAttribute.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Xml {

    [IgnoreNamespace]
    [Imported]
    public sealed class XmlAttribute : XmlNode {

        internal XmlAttribute() {
        }

        [ScriptProperty]
        public override string Name {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public bool Specified {
            get {
                return false;
            }
        }

        [ScriptProperty]
        public override string Value {
            get {
                return null;
            }
            set {
            }
        }
    }
}
