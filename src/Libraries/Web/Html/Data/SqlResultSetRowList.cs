// SqlResultSetRowList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace System.Html.Data.Sql {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlResultSetRowList {

        private SqlResultSetRowList() {
        }

        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        public SqlResultSetRow Item(int index) {
            return null;
        }
    }
}
