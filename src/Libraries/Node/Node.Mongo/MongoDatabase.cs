// MongoDatabase.cs
// Script#/Libraries/Node/Mongo
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.MongoDB {

    [ScriptImport]
    [ScriptName("Db")]
    public sealed class MongoDatabase {

        public MongoDatabase(string name, MongoServer server) {
        }

        public MongoDatabase(string name, MongoServer server, object options) {
        }

        public void Authenticate(string userName, string password, AsyncResultCallback<bool> successCallback) {
        }

        public void Close() {
        }

        public void Close(AsyncCallback callback) {
        }

        public void Close(bool forceClose, AsyncCallback callback) {
        }

        public static void Connection(string url, AsyncResultCallback<MongoDatabase> callback) {
        }

        public void CreateCollection(string name, AsyncResultCallback<MongoCollection> callback) {
        }

        public void CreateCollection(string name, object options, AsyncResultCallback<MongoCollection> callback) {
        }

        public void DropCollection(string name, AsyncCallback callback) {
        }

        [ScriptName("admin")]
        public void GetAdminDatabase(AsyncResultCallback<MongoDatabase> callback) {
        }

        [ScriptName("collection")]
        public void GetCollection(string name, AsyncResultCallback<MongoCollection> callback) {
        }

        [ScriptName("collection")]
        public void GetCollection(string name, object options, AsyncResultCallback<MongoCollection> callback) {
        }

        [ScriptName("collectionsInfo")]
        public void GetCollectionInfo(string name, AsyncResultCallback<object> callback) {
        }

        [ScriptName("collectionNames")]
        public void GetCollectionNames(AsyncResultCallback<object> callback) {
        }

        [ScriptName("collectionNames")]
        public void GetCollectionNames(string name, AsyncResultCallback<object> callback) {
        }

        [ScriptName("collectionNames")]
        public void GetCollectionNames(string name, object options, AsyncResultCallback<object> callback) {
        }

        [ScriptName("db")]
        public MongoDatabase GetDatabase(string name) {
            return null;
        }

        public void Open(AsyncResultCallback<MongoDatabase> callback) {
        }

        public void RemoveCollection(string fromName, string toName, AsyncCallback callback) {
        }
    }
}
