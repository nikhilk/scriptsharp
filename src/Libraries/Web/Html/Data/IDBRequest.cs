using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBRequest {

        protected IDBRequest() {
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
        public IDBTransaction Transaction {
            get { return null; }
        }

        [ScriptField]
        public string ReadyState {
            get { return null; }
        }

        public IDBRequestDelegate Onsuccess;

        public IDBRequestDelegate Onerror;
    }

    public delegate void IDBRequestDelegate(IDBEvent<IDBRequest> e);

}
