using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBOpenDBRequest : DBRequest {

        protected DBOpenDBRequest() {
        }

        [ScriptName("onblocked")]
        public DBOpenDBRequestCallback OnBlocked;

        [ScriptName("onupgradeneeded")]
        public DBOpenDBRequestVersionChangeCallback OnUpgradeNeeded;
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBOpenDBRequestCallback(DBEvent<DBOpenDBRequest> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBOpenDBRequestVersionChangeCallback(DBVersionChangeEvent<DBOpenDBRequest> e);
}
