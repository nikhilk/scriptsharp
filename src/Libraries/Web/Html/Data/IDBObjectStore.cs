using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBObjectStore {

        private IDBObjectStore() {
        }

        [ScriptField]
        public string Name {
            get { return default(string); }
        }

        [ScriptField]
        public string KeyPath {
            get { return default(string); }
        }

        [ScriptField]
        public string[] IndexNames {
            get { return default(string[]); }
        }

        [ScriptField]
        public IDBTransaction Transaction {
            get { return default(IDBTransaction); }
        }

        [ScriptField]
        public bool AutoIncremenent {
            get { return default(bool); }
        }

        public IDBRequest Put(object value) {
            return null;
        }

        public IDBRequest Put(object value, object key) {
            return null;
        }

        public IDBRequest Add(object value) {
            return null;
        }

        public IDBRequest Add(object value, object key) {
            return null;
        }

        public IDBRequest Delete(object key) {
            return null;
        }

        public IDBRequest Get(object key) {
            return null;
        }

        public IDBRequest Clear() {
            return null;
        }

        public IDBRequest OpenCursor() {
            return null;
        }

        public IDBRequest OpenCursor(object range) {
            return null;
        }

        public IDBRequest OpenCursor(object range, string direction) {
            return null;
        }

        public IDBIndex CreateIndex(string name, object keyPath) {
            return default(IDBIndex);
        }

        public IDBIndex CreateIndex(string name, object keyPath, IDBIndexParameters optionalParameters) {
            return default(IDBIndex);
        }

        public IDBIndex Index(string name) {
            return default(IDBIndex);
        }

        public void DeleteIndex(string indexName) {
        }

        public IDBRequest Count() {
            return null;
        }

        public IDBRequest Count(object key) {
            return null;
        }
    }
}
