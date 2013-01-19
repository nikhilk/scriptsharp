using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBIndex {

        private DBIndex() {
        }

        [ScriptField]
        public string Name {
            get { return default(string); }
        }

        [ScriptField]
        public DBObjectStore ObjectStore {
            get { return default(DBObjectStore); }
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

        public DBRequest OpenCursor() {
            return null;
        }

        public DBRequest OpenCursor(object range) {
            return null;
        }

        public DBRequest OpenCursor(object range, string direction) {
            return null;
        }

        public DBRequest OpenKeyCursor() {
            return null;
        }

        public DBRequest OpenKeyCursor(object range) {
            return null;
        }

        public DBRequest OpenKeyCursor(object range, string direction) {
            return null;
        }

        public DBRequest Get(object key) {
            return null;
        }

        public DBRequest GetKey(object key) {
            return null;
        }

        public DBRequest Count() {
            return null;
        }

        public DBRequest Count(object key) {
            return null;
        }
    }
}
