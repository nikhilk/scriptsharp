// CloudBlobListContinuation.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudBlobListContinuation {

        private CloudBlobListContinuation() {
        }

        [ScriptField]
        public string NextMarker {
            get {
                return null;
            }
        }

        public void GetNextPage(AsyncResultCallback<List<CloudBlob>, CloudBlobListContinuation> callback) {
        }

        public bool HasNextPage() {
            return false;
        }
    }
}
