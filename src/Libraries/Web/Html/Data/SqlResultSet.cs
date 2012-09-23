// SqlResultSet.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace System.Html.Data {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class SqlResultSet {

        private SqlResultSet() {
        }

        [ScriptProperty]
        public int InsertId {
            get {
                return 0;
            }
        }

        [ScriptProperty]
        public SqlResultSetRowList Rows {
            get {
                return null;
            }
        }

        [ScriptProperty]
        public int RowsAffected {
            get {
                return 0;
            }
        }
    }
}
