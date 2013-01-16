using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBTransaction {

        private IDBTransaction() {
        }

        [ScriptField]
        public string Mode {
            get { return null; }
        }

        [ScriptField]
        public IDBDatabase Db {
            get { return null; }
        }

        [ScriptField]
        public object Error {
            get { return null; }
        }

        public IDBObjectStore ObjectStore(string name) {
            return null;
        }

        public void Abort() {
        }

        public IDBTransactionDelegate Onabort;

        public IDBTransactionDelegate Oncomplete;

        public IDBTransactionDelegate Onerror;

    }

    public delegate void IDBTransactionDelegate(IDBEvent<IDBTransaction> e);

}
