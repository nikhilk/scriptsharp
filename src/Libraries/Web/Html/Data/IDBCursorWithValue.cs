using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBCursorWithValue : IDBCursor {

        private IDBCursorWithValue() {
        }

        [ScriptField]
        public object Value {
            get {
                return null;
            }
        }
    }
}
