// DBObjectStore.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBObjectStore {

        private DBObjectStore() {
        }

        [ScriptField]
        public bool AutoIncremenent {
            get {
                return default(bool);
            }
        }

        [ScriptField]
        public string[] IndexNames {
            get {
                return default(string[]);
            }
        }

        [ScriptField]
        public string KeyPath {
            get {
                return default(string);
            }
        }

        [ScriptField]
        public string Name {
            get {
                return default(string);
            }
        }

        [ScriptField]
        public DBTransaction Transaction {
            get {
                return default(DBTransaction);
            }
        }

        public DBRequest Add(object value) {
            return null;
        }

        public DBRequest Add(object value, object key) {
            return null;
        }

        public DBRequest Clear() {
            return null;
        }

        public DBRequest Count() {
            return null;
        }

        public DBRequest Count(object key) {
            return null;
        }

        public DBIndex CreateIndex(string name, object keyPath) {
            return default(DBIndex);
        }

        public DBIndex CreateIndex(string name, object keyPath, DBIndexParameters optionalParameters) {
            return default(DBIndex);
        }

        public DBRequest Delete(object key) {
            return null;
        }

        public void DeleteIndex(string indexName) {
        }

        public DBRequest Get(object key) {
            return null;
        }

        public DBIndex Index(string name) {
            return default(DBIndex);
        }

        public DBRequest OpenCursor() {
            return null;
        }

        public DBRequest OpenCursor(object range) {
            return null;
        }

        public DBRequest OpenCursor(object range, string direction) {
            return null;
        }

        public DBRequest Put(object value) {
            return null;
        }

        public DBRequest Put(object value, object key) {
            return null;
        }
    }
}
