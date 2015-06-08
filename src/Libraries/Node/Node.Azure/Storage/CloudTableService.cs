// CloudTableService.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.WindowsAzure.Storage {

    // TODO: Properties, metadata related APIs
    // TODO: Does azure sdk support shared access signature functionality for tables?

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudTableService {

        private CloudTableService() {
        }

        public void BeginBatch() {
        }

        public void CommitBatch(AsyncCallback callback) {
        }

        public void CommitBatch(object options, AsyncCallback callback) {
        }

        public void CreateTable(string tableName, AsyncCallback callback) {
        }

        public void CreateTable(string tableName, object options, AsyncCallback callback) {
        }

        public void CreateTableIfNotExists(string tableName, AsyncResultCallback<bool> callback) {
        }

        public void CreateTableIfNotExists(string tableName, object options, AsyncResultCallback<bool> callback) {
        }

        public void DeleteEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<bool> callback) {
        }

        public void DeleteEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<bool> callback) {
        }

        public void DeleteTable(string tableName, AsyncResultCallback<bool> callback) {
        }

        public void DeleteTable(string tableName, object options, AsyncResultCallback<bool> callback) {
        }

        public bool HasOperations() {
            return false;
        }

        public void InsertEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void InsertEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void InsertOrMergeEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void InsertOrMergeEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void InsertOrReplaceEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void InsertOrReplaceEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public bool IsInBatch() {
            return false;
        }

        [ScriptName("queryTables")]
        public void ListTables(AsyncResultCallback<List<CloudTable>> callback) {
        }

        [ScriptName("queryTables")]
        public void ListTables(AsyncResultCallback<List<CloudTable>, CloudTableListContinuation> callback) {
        }

        [ScriptName("queryTables")]
        public void ListTables(object options, AsyncResultCallback<List<CloudTable>> callback) {
        }

        [ScriptName("queryTables")]
        public void ListTables(object options, AsyncResultCallback<List<CloudTable>, CloudTableListContinuation> callback) {
        }

        public void MergeEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void MergeEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void QueryEntities(CloudTableQuery query, AsyncResultCallback<List<CloudTableEntity>> callback) {
        }

        public void QueryEntities(CloudTableQuery query, object options, AsyncResultCallback<List<CloudTableEntity>> callback) {
        }

        public void QueryEntities(CloudTableQuery query, AsyncResultCallback<List<CloudTableEntity>, CloudTableQueryContinuation> callback) {
        }

        public void QueryEntities(CloudTableQuery query, object options, AsyncResultCallback<List<CloudTableEntity>, CloudTableQueryContinuation> callback) {
        }

        public void QueryEntity(string tableName, string partitionKey, string rowKey, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void QueryEntity(string tableName, string partitionKey, string rowKey, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void Rollback() {
        }

        public void UpdateEntity(string tableName, CloudTableEntity entity, AsyncResultCallback<CloudTableEntity> callback) {
        }

        public void UpdateEntity(string tableName, CloudTableEntity entity, object options, AsyncResultCallback<CloudTableEntity> callback) {
        }
    }
}
