// DBOpenDBRequest.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBOpenDBRequest : DBRequest {

        private DBOpenDBRequest() {
        }

        [ScriptName("onblocked")]
        [ScriptField]
        public DBOpenDBRequestCallback OnBlocked {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptName("onupgradeneeded")]
        [ScriptField]
        public DBOpenDBRequestVersionChangeCallback OnUpgradeNeeded {
            get {
                return null;
            }
            set {
            }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBOpenDBRequestCallback(DBEvent<DBOpenDBRequest> e);

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public delegate void DBOpenDBRequestVersionChangeCallback(DBVersionChangeEvent<DBOpenDBRequest> e);
}
