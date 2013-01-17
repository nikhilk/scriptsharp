using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBOpenDBRequest : IDBRequest {

        protected IDBOpenDBRequest() {
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        public event IDBOpenDBRequestCallback Blocked {
            add {
            }
            remove {
            }
        }

        [ScriptEvent("addEventListener", "removeEventListener")]
        [ScriptName("upgradeneeded")]
        public event IDBOpenDBRequestVersionChangeCallback UpgradeNeeded {
            add {
            }
            remove {
            }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestCallback(IDBEvent<IDBOpenDBRequest> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestVersionChangeCallback(IDBVersionChangeEvent<IDBOpenDBRequest> e);
}
