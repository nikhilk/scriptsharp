// DBRequest.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBRequest : DBEventTarget {

        internal DBRequest() {
        }

        [ScriptField]
        public object Error {
            get {
                return null;
            }
        }

        [ScriptName("onerror")]
        [ScriptField]
        public DBRequestCallback OnError {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onsuccess")]
        [ScriptField]
        public DBRequestCallback OnSuccess {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public string ReadyState {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Result {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Source {
            get {
                return null;
            }
        }

        [ScriptField]
        public DBTransaction Transaction {
            get {
                return null;
            }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBRequestCallback(DBEvent<DBRequest> e);
}
