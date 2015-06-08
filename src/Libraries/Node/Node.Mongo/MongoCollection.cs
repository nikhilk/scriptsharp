// MongoCollection.cs
// Script#/Libraries/Node/Mongo
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.MongoDB {

    [ScriptImport]
    [ScriptName("Collection")]
    public sealed class MongoCollection {

        public MongoCollection(MongoDatabase database, string name) {
        }

        public MongoCollection(MongoDatabase database, string name, object options) {
        }

        public void Count(AsyncResultCallback<int> callback) {
        }

        public void Count(object query, AsyncResultCallback<int> callback) {
        }

        public void Count(object query, object options, AsyncResultCallback<int> callback) {
        }

        public void Distinct(string key, AsyncResultCallback<object[]> callback) {
        }

        public void Distinct(string key, object query, AsyncResultCallback<object[]> callback) {
        }

        public void Distinct(string key, object query, object options, AsyncResultCallback<object[]> callback) {
        }

        public void Drop(AsyncCallback callback) {
        }

        public MongoCursor Find(object query) {
            return null;
        }

        public MongoCursor Find(object query, object options) {
            return null;
        }

        public void FindAndModify(object query, object[] sort, object document, AsyncResultCallback<object> callback) {
        }

        public void FindAndModify(object query, object[] sort, object document, object options, AsyncResultCallback<object> callback) {
        }

        public void FindAndRemove(object query, object[] sort, AsyncResultCallback<object> callback) {
        }

        public void FindAndRemove(object query, object[] sort, object options, AsyncResultCallback<object> callback) {
        }

        public MongoCursor FindOne(object query, AsyncResultCallback<object> callback) {
            return null;
        }

        public MongoCursor FindOne(object query, object options, AsyncResultCallback<object> callback) {
            return null;
        }

        public void Insert(object[] documents) {
        }

        public void Insert(object[] documents, object options) {
        }

        public void Insert(object[] documents, object options, AsyncCallback callback) {
        }

        public void Remove() {
        }

        public void Remove(AsyncCallback callback) {
        }

        public void Remove(object selector) {
        }

        public void Remove(object selector, AsyncCallback callback) {
        }

        public void Remove(object selector, object options, AsyncCallback callback) {
        }

        public void Rename(string newName, AsyncCallback callback) {
        }

        public void Update(object selector, object document) {
        }

        public void Update(object selector, object document, AsyncCallback callback) {
        }

        public void Update(object selector, object document, object options, AsyncCallback callback) {
        }
    }
}
