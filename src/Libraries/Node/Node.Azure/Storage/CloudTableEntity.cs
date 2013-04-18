// CloudTableEntity.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("Object")]
    public sealed class CloudTableEntity {

        public CloudTableEntity() {
        }

        public CloudTableEntity(params object[] nameValuePairs) {
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public string PartitionKey {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public string RowKey {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public object this[string key] {
            get {
                return null;
            }
            set {
            }
        }

        public static implicit operator Dictionary<string, object>(CloudTableEntity entity) {
            return null;
        }

        public static implicit operator CloudTableEntity(Dictionary<string, object> data) {
            return null;
        }
    }
}
