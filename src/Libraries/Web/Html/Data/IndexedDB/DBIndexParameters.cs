// DBIndexParameters.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.Data.IndexedDB {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class DBIndexParameters {

        [ScriptField]
        public bool MultiEntry {
            get {
                return false;
            }
            set {
            }
        }

        [ScriptField]
        public bool Unique {
            get {
                return false;
            }
            set {
            }
        }
    }
}
