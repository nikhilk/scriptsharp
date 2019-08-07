// DBEvent.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBEvent<T> {

        internal DBEvent() {
        }

        [ScriptField]
        public T Target {
            get {
                return default(T);
            }
        }

        [ScriptField]
        public string Type {
            get {
                return null;
            }
        }
    }
}
