// CloudBlobLease.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public abstract class CloudBlobLease {

        internal CloudBlobLease() {
        }

        [ScriptField]
        public string ID {
            get {
                return null;
            }
        }
    }
}
