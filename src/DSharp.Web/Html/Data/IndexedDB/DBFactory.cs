// DBFactory.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class DBFactory {

        private DBFactory() {
        }

        [ScriptName("cmp")]
        public int Compare(object first, object last) {
            return default(short);
        }

        public DBOpenDBRequest DeleteDatabase(string name) {
            return null;
        }

        public DBOpenDBRequest Open(string name) {
            return null;
        }

        public DBOpenDBRequest Open(string name, long version) {
            return null;
        }
    }
}
