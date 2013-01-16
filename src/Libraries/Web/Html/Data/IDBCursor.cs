using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBCursor {

        protected IDBCursor() {
        }

        [ScriptField]
        public object Source {
            get { return null; }
        }

        [ScriptField]
        public string Direction {
            get { return null; }
        }

        [ScriptField]
        public object Key {
            get { return null; }
        }

        [ScriptField]
        public object PrimaryKey {
            get { return null; }
        }

        public IDBRequest Update(object value) {
            return null;
        }

        public void Advance(long count) {
        }

        public void Continue() {
        }

        public void Continue(object key) {
        }

        public IDBRequest Delete(object value) {
            return null;
        }
    }
}
