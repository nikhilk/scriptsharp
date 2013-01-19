using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBFactory {

        private DBFactory() {
        }

        public DBOpenDBRequest Open(string name) {
            return null;
        }

        public DBOpenDBRequest Open(string name, long version) {
            return null;
        }

        public DBOpenDBRequest DeleteDatabase(string name) {
            return null;
        }

        public short Cmp(object first, object last) {
            return default(short);
        }
    }
}
