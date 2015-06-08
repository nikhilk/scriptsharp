// CloudTableQuery.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptName("azure.TableQuery")]
    public sealed class CloudTableQuery {

        public CloudTableQuery And(string filter, object[] values) {
            return null;
        }

        public CloudTableQuery From(string tableName) {
            return null;
        }

        public CloudTableQuery Or(string filter, object[] values) {
            return null;
        }

        public CloudTableQuery Select() {
            return null;
        }

        public CloudTableQuery Select(string[] fields) {
            return null;
        }

        public CloudTableQuery Top(int count) {
            return null;
        }

        public CloudTableQuery Where(string filter, string value) {
            return null;
        }

        public CloudTableQuery Where(string filter, object[] values) {
            return null;
        }

        public CloudTableQuery WhereKeys(string partitionKey, string rowKey) {
            return null;
        }

        public CloudTableQuery WhereNextKeys(string partitionKey, string rowKey) {
            return null;
        }
    }
}
