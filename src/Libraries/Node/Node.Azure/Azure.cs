// Azure.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using NodeApi.WindowsAzure.Runtime;
using NodeApi.WindowsAzure.Storage;

namespace NodeApi.WindowsAzure {

    /// <summary>
    /// The root Azure services API.
    /// </summary>
    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("azure")]
    public static class Azure {

        [ScriptField]
        [ScriptName(PreserveCase = true)]
        public static RoleEnvironment RoleEnvironment {
            get {
                return null;
            }
        }

        public static CloudBlobService CreateBlobService() {
            return null;
        }

        public static CloudBlobService CreateBlobService(string storageAccount, string accessKey) {
            return null;
        }

        public static CloudQueueService CreateQueueService() {
            return null;
        }

        public static CloudQueueService CreateQueueService(string storageAccount, string accessKey) {
            return null;
        }

        public static CloudTableService CreateTableService() {
            return null;
        }

        public static CloudTableService CreateTableService(string storageAccount, string accessKey) {
            return null;
        }
    }
}
