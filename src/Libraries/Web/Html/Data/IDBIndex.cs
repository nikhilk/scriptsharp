using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBIndex {

        private IDBIndex() {
        }

        [ScriptField]
        public string Name {
            get { return default(string); }
        }

        [ScriptField]
        public IDBObjectStore ObjectStore {
            get { return default(IDBObjectStore); }
        }

        [ScriptField]
        public string KeyPath {
            get { return default(string); }
        }

        [ScriptField]
        public bool MultiEntry {
            get { return default(bool); }
        }

        [ScriptField]
        public bool Unique {
            get { return default(bool); }
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

        public IDBRequest OpenKeyCursor() {
            return null;
        }

        public IDBRequest OpenKeyCursor(object range) {
            return null;
        }

        public IDBRequest OpenKeyCursor(object range, string direction) {
            return null;
        }

        public IDBRequest Get(object key) {
            return null;
        }

        public IDBRequest GetKey(object key) {
            return null;
        }

        public IDBRequest Count() {
            return null;
        }

        public IDBRequest Count(object key) {
            return null;
        }
    }
}
