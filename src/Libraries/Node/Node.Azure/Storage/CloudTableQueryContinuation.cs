// CloudTableQueryContinuation.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudTableQueryContinuation {

        private CloudTableQueryContinuation() {
        }

        [ScriptField]
        public string NextPartitionKey {
            get {
                return null;
            }
        }

        [ScriptField]
        public string NextRowKey {
            get {
                return null;
            }
        }

        public void GetNextPage(AsyncResultCallback<CloudTableEntity[], CloudTableQueryContinuation> callback) {
        }

        public bool HasNextPage() {
            return false;
        }
    }
}
