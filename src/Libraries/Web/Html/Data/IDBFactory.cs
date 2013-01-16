using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBFactory {

        private IDBFactory() {
        }

        public IDBOpenDBRequest Open(string name) {
            return null;
        }

        public IDBOpenDBRequest Open(string name, long version) {
            return null;
        }

        public IDBOpenDBRequest DeleteDatabase(string name) {
            return null;
        }

        public short Cmp(object first, object last) {
            return default(short);
        }
    }
}
