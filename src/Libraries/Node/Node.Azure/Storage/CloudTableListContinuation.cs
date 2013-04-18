// CloudTableListContinuation.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudTableListContinuation {

        private CloudTableListContinuation() {
        }

        [ScriptField]
        public string NextTableName {
            get {
                return null;
            }
        }

        public void GetNextPage(AsyncResultCallback<CloudTable[], CloudTableListContinuation> callback) {
        }

        public bool HasNextPage() {
            return false;
        }
    }
}
