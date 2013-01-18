using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBRequest : IDBEventTarget {

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
        public IDBRequestCallback OnSuccess;

        [ScriptName("onerror")]
        public IDBRequestCallback OnError;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBRequestCallback(IDBEvent<IDBRequest> e);

}
