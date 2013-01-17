﻿using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBEvent<T> {

        [ScriptField]
        public string Type {
            get { return null; }
        }

        [ScriptField]
        public T Target {
            get { return default(T); }
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class IDBVersionChangeEvent<T> : IDBEvent<T> {

        [ScriptField]
        public long OldVersion {
            get { return default(long); }
        }

        [ScriptField]
        public long NewVersion {
            get { return default(long); }
        }
    }

}