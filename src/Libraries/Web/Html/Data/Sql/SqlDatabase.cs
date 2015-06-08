// SqlDatabase.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.Sql {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlDatabase {

        private SqlDatabase() {
        }

        [ScriptField]
        public string Version {
            get {
                return null;
            }
        }

        public void ChangeVersion(string oldVersion, string newVersion, SqlTransactionCallback callback, SqlErrorCallback errorCallback, Action successCallback) {
        }

        public void ReadTransaction(SqlTransactionCallback callback, SqlErrorCallback errorCallback, Action successCallback) {
        }

        public void Transaction(SqlTransactionCallback callback, SqlErrorCallback errorCallback, Action successCallback) {
        }
    }

    public delegate bool SqlDatabaseCallback(SqlDatabase db);
}
