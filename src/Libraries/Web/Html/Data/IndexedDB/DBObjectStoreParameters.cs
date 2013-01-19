using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class DBObjectStoreParameters {

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

