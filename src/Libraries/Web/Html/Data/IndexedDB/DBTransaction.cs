using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBTransaction : DBEventTarget {

        private DBTransaction() {
        }

        [ScriptField]
        public string Mode {
            get { return null; }
        }

        [ScriptField]
        public DBDatabase Db {
            get { return null; }
        }

        [ScriptField]
        public object Error {
            get { return null; }
        }

        public DBObjectStore ObjectStore(string name) {
            return null;
        }

        public void Abort() {
        }

        [ScriptName("onabort")]
        public DBTransactionCallback OnAbort;

        [ScriptName("oncomplete")]
        public DBTransactionCallback OnComplete;

        [ScriptName("onerror")]
        public DBTransactionCallback OnError;

    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBTransactionCallback(DBEvent<DBTransaction> e);

}
