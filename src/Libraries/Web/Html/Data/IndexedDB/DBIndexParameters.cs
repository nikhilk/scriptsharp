using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class DBIndexParameters {

        [ScriptField]
        public bool Unique {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public bool MultiEntry {
            get {
                return false;
            }
            set {
            }
        }
    }
}
