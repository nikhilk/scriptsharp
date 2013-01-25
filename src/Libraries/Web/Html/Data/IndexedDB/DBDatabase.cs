using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBDatabase : DBEventTarget {

        private DBDatabase() {
        }

        [ScriptField]
        public string Name {
            get { return default(string); }
        }

        [ScriptField]
        public long Version {
            get { return default(long); }
        }

        [ScriptField]
        public string[] ObjectStoreNames {
            get { return default(string[]); }
        }

        public DBObjectStore CreateObjectStore(string name) {
            return default(DBObjectStore);
        }

        public DBObjectStore CreateObjectStore(string name, DBObjectStoreParameters optionalParameters) {
            return default(DBObjectStore);
        }

        public void DeleteObjectStore(string name) {
        }
        
        public DBTransaction Transaction(string[] storenames) {
            return default(DBTransaction);
        }

        public DBTransaction Transaction(string[] storenames, string mode) {
            return default(DBTransaction);
        }

        public void Close() {
        }

        [ScriptName("onabort")]
        public DBDatabaseCallback OnAbort;

        [ScriptName("onerror")]
        public DBDatabaseCallback OnError;

        [ScriptName("onversionchange")]
        public DBDatabaseVersionChangeCallback OnVersionChange;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBDatabaseCallback(DBEvent<DBDatabase> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBDatabaseVersionChangeCallback(DBVersionChangeEvent<DBDatabase> e);

}
