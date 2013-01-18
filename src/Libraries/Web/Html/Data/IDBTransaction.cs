using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBTransaction : IDBEventTarget {

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

        [ScriptName("onabort")]
        public IDBTransactionCallback OnAbort;

        [ScriptName("oncomplete")]
        public IDBTransactionCallback OnComplete;

        [ScriptName("onerror")]
        public IDBTransactionCallback OnError;

    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBTransactionCallback(IDBEvent<IDBTransaction> e);

}
