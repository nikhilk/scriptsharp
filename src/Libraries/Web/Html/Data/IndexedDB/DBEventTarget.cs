// DBEventTarget.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public abstract class DBEventTarget {

        internal DBEventTarget() {
        }

        public void AddEventListener<T>(string type, Action<T> listener) {
        }

        public void AddEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }
    }
}
