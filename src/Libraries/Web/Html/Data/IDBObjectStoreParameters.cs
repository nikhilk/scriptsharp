using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class IDBObjectStoreParameters {

        [ScriptField]
        public string KeyPath {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public bool AutoIncrement {
            get {
                return false;
            }
            set {
            }
        }
    }
}

