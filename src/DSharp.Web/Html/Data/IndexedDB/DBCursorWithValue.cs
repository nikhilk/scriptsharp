// DBCursorWithValue.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBCursorWithValue : DBCursor {

        private DBCursorWithValue() {
        }

        [ScriptField]
        public object Value {
            get {
                return null;
            }
        }
    }
}
