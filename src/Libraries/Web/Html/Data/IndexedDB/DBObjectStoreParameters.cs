// DBObjectStoreParameters.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class DBObjectStoreParameters {

        [ScriptField]
        public bool AutoIncrement {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public string KeyPath {
            get {
                return null;
            }
            set {
            }
        }
    }
}

