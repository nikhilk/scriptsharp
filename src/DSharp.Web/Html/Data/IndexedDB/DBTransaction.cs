// DBTransaction.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBTransaction : DBEventTarget {

        private DBTransaction() {
        }

        [ScriptField]
        [ScriptName("db")]
        public DBDatabase Database {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Error {
            get {
                return null;
            }
        }

        [ScriptField]
        public string Mode {
            get {
                return null;
            }
        }

        [ScriptName("onabort")]
        [ScriptField]
        public DBTransactionCallback OnAbort {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("oncomplete")]
        [ScriptField]
        public DBTransactionCallback OnComplete {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onerror")]
        [ScriptField]
        public DBTransactionCallback OnError {
            get {
                return null;
            }
            set {
            }
        }

        public void Abort() {
        }

        public DBObjectStore ObjectStore(string name) {
            return null;
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBTransactionCallback(DBEvent<DBTransaction> e);
}
