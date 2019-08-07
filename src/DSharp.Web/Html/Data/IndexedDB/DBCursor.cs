// DBCursor.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBCursor {

        internal DBCursor() {
        }

        [ScriptField]
        public string Direction {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Key {
            get {
                return null;
            }
        }

        [ScriptField]
        public object PrimaryKey {
            get {
                return null;
            }
        }

        [ScriptField]
        public object Source {
            get {
                return null;
            }
        }

        public void Advance(long count) {
        }

        public void Continue() {
        }

        public void Continue(object key) {
        }

        public DBRequest Delete(object value) {
            return null;
        }

        public DBRequest Update(object value) {
            return null;
        }
    }
}
