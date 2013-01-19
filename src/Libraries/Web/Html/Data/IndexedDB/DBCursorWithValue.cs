using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBCursorWithValue : DBCursor {

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
