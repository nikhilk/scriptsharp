// CloudBlobContainerListContinuation.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudBlobContainerListContinuation {

        private CloudBlobContainerListContinuation() {
        }

        [ScriptField]
        public string NextMarker {
            get {
                return null;
            }
        }

        public void GetNextPage(AsyncResultCallback<CloudBlobContainer[], CloudBlobContainerListContinuation> callback) {
        }

        public bool HasNextPage() {
            return false;
        }
    }
}
