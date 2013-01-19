using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBRequest : DBEventTarget {

        protected DBRequest() {
        }

        [ScriptField]
        public object Result {
            get { return null; }
        }

        [ScriptField]
        public object Error {
            get { return null; }
        }

        [ScriptField]
        public object Source {
            get { return null; }
        }

        [ScriptField]
        public DBTransaction Transaction {
            get { return null; }
        }

        [ScriptField]
        public string ReadyState {
            get { return null; }
        }

        [ScriptName("onsuccess")]
        public DBRequestCallback OnSuccess;

        [ScriptName("onerror")]
        public DBRequestCallback OnError;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBRequestCallback(DBEvent<DBRequest> e);

}
