using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBOpenDBRequest : IDBRequest {

        protected IDBOpenDBRequest() {
        }

        public IDBOpenDBRequestDelegate Onblocked;

        public IDBOpenDBRequestVersionChangeDelegate Onupgradeneeded;
    }

    public delegate void IDBOpenDBRequestDelegate(IDBEvent<IDBOpenDBRequest> e);

    public delegate void IDBOpenDBRequestVersionChangeDelegate(IDBVersionChangeEvent<IDBOpenDBRequest> e);
}
