using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBOpenDBRequest : IDBRequest {

        protected IDBOpenDBRequest() {
        }

        [ScriptName("onblocked")]
        public IDBOpenDBRequestCallback OnBlocked;

        [ScriptName("onupgradeneeded")]
        public IDBOpenDBRequestVersionChangeCallback OnUpgradeNeeded;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestCallback(IDBEvent<IDBOpenDBRequest> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void IDBOpenDBRequestVersionChangeCallback(IDBVersionChangeEvent<IDBOpenDBRequest> e);
}
