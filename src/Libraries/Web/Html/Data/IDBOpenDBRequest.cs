using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBOpenDBRequest : IDBRequest {

        protected IDBOpenDBRequest() {
        }

        [ScriptName("onblocked")]
        public IDBOpenDBRequestDelegate OnBlocked;

        [ScriptName("onupgradeneeded")]
        public IDBOpenDBRequestVersionChangeDelegate OnUpgradeNeeded;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestDelegate(IDBEvent<IDBOpenDBRequest> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestVersionChangeDelegate(IDBVersionChangeEvent<IDBOpenDBRequest> e);
}
