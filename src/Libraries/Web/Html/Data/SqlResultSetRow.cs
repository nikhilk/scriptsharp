// SqlResultSetRow.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace System.Html.Data.Sql {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class SqlResultSetRow {

        private SqlResultSetRow() {
        }

        [ScriptField]
        public object this[string name] {
            get {
                return null;
            }
        }
    }
}
