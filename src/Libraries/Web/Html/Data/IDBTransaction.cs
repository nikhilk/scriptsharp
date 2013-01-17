using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class IDBTransaction {

        private IDBTransaction() {
        }

        [ScriptField]
        public string Mode {
            get { return null; }
        }

        [ScriptField]
        public IDBDatabase Db {
            get { return null; }
        }

        [ScriptField]
        [ScriptName("error")]
        public object ErrorObject {
            get { return null; }
        }

        public IDBObjectStore ObjectStore(string name) {
            return null;
        }

        [ScriptName("abort")]
        public void AbortTransaction() {
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBTransactionCallback Abort{
            add {
            }
            remove {
            }
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBTransactionCallback Complete {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBTransactionCallback Error {
            add {
            }
            remove {
            }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBTransactionCallback(IDBEvent<IDBTransaction> e);

}
