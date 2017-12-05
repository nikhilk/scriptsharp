// DBDatabase.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

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
            get {
                return default(string);
            }
        }

        [ScriptField]
        public string[] ObjectStoreNames {
            get {
                return default(string[]);
            }
        }

        [ScriptName("onabort")]
        [ScriptField]
        public DBDatabaseCallback OnAbort {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onerror")]
        [ScriptField]
        public DBDatabaseCallback OnError {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onversionchange")]
        [ScriptField]
        public DBDatabaseVersionChangeCallback OnVersionChange {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public long Version {
            get {
                return default(long);
            }
        }

        public void Close() {
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
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBDatabaseCallback(DBEvent<DBDatabase> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBDatabaseVersionChangeCallback(DBVersionChangeEvent<DBDatabase> e);
}
