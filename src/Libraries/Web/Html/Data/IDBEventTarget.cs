using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBEventTarget {

        public void AddEventListener<T>(string type, Action<T> listener) {
        }

        public void AddEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener) {
        }

        public void RemoveEventListener<T>(string type, Action<T> listener, bool useCapture) {
        }

        public bool DispatchEvent<T>(IDBEvent<T> e) {
            return false;
        }
    }
}
