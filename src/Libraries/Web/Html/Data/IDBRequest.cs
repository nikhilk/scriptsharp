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

        [ScriptName("onsuccess")]
        public IDBRequestDelegate OnSuccess;

        [ScriptName("onerror")]
        public IDBRequestDelegate OnError;
    }

    public delegate void IDBRequestDelegate(IDBEvent<IDBRequest> e);

}
