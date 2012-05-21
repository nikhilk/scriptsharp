// SqlResultSet.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace System.Html.Data {

    [IgnoreNamespace]
    [Imported]
    public sealed class SqlResultSet {

        private SqlResultSet() {
        }

        [IntrinsicProperty]
        public int InsertId {
            get {
                return 0;
            }
        }

        [IntrinsicProperty]
        public SqlResultSetRowList Rows {
            get {
                return null;
            }
        }

        [IntrinsicProperty]
        public int RowsAffected {
            get {
                return 0;
            }
        }
    }
}
