// MongoClient.cs
// Script#/Libraries/Node/Mongo
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.MongoDB {

    [ScriptImport]
    public sealed class MongoClient {

        public MongoClient(MongoServer server) {
        }

        public void Close() {
        }

        public void Close(AsyncCallback callback) {
        }

        public static void Connect(string url, AsyncResultCallback<MongoClient> callback) {
        }

        public static void Connect(string url, object options, AsyncResultCallback<MongoDatabase> callback) {
        }

        [ScriptName("db")]
        public MongoDatabase GetDatabase(string name) {
            return null;
        }

        public void Open(AsyncResultCallback<MongoClient> callback) {
        }
    }
}
