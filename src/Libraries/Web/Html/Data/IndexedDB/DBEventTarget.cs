using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class DBEventTarget {

        public void AddEventListener<T>(string type, Action<T> listener) {
        }

        public void AddEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }

        public bool DispatchEvent<T>(DBEvent<T> e) {
            return false;
        }
    }
}
