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
        [ScriptName("error")]
        public object ErrorObject {
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

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBRequestCallback Success {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBRequestCallback Error {
            add {
            }
            remove {
            }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBRequestCallback(IDBEvent<IDBRequest> e);

}
