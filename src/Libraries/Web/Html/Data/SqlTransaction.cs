// SqlTransaction.cs
// Script#/Libraries/Web
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    public delegate bool SqlTransactionCallback(SqlTransaction transaction);

    public delegate bool SqlStatementCallback(SqlTransaction transaction, SqlResultSet resultSet);

    public delegate bool SqlStatementErrorCallback(SqlTransaction transaction, SqlError error);

    [IgnoreNamespace]
    [Imported]
    public sealed class SqlTransaction {

        private SqlTransaction() {
        }

        public void ExecuteSql(string sql, object[] arguments, SqlStatementCallback callback, SqlStatementErrorCallback errorCallback) {
        }
    }
}
