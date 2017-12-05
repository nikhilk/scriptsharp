// SqlTransaction.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.Sql {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlTransaction {

        private SqlTransaction() {
        }

        public void ExecuteSql(string sql, object[] arguments, SqlStatementCallback callback, SqlStatementErrorCallback errorCallback) {
        }
    }

    public delegate bool SqlTransactionCallback(SqlTransaction transaction);

    public delegate bool SqlStatementCallback(SqlTransaction transaction, SqlResultSet resultSet);

    public delegate bool SqlStatementErrorCallback(SqlTransaction transaction, SqlError error);
}
