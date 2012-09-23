// SqlResultSetRow.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace System.Html.Data {

    [IgnoreNamespace]
    [ScriptImport]
    public sealed class SqlResultSetRow {

        private SqlResultSetRow() {
        }

        [ScriptProperty]
        public object this[string name] {
            get {
                return null;
            }
        }
    }
}
