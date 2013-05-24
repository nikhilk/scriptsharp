// CloudQueueService.cs
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
    public sealed class CloudQueueService {

        private CloudQueueService() {
        }

        public void ClearMessages(string queueName, AsyncCallback callback) {
        }

        public void ClearMessages(string queueName, object options, AsyncCallback callback) {
        }

        public void CreateMessage(string queueName, string message, AsyncCallback callback) {
        }

        public void CreateMessage(string queueName, string message, object options, AsyncCallback callback) {
        }

        public void CreateQueue(string queueName, AsyncCallback callback) {
        }

        public void CreateQueue(string queueName, object options, AsyncCallback callback) {
        }

        public void CreateQueueIfNotExists(string queueName, AsyncCallback callback) {
        }

        public void CreateQueueIfNotExists(string queueName, object options, AsyncCallback callback) {
        }

        public void DeleteMessage(string queueName, string messageID, string popReceipt, AsyncCallback callback) {
        }

        public void DeleteMessage(string queueName, string messageID, string popReceipt, object options, AsyncCallback callback) {
        }

        public void DeleteQueue(string queueName, AsyncCallback callback) {
        }

        public void DeleteQueue(string queueName, object options, AsyncCallback callback) {
        }

        public void GetMessages(string queueName, AsyncResultCallback<List<CloudQueueMessage>> callback) {
        }

        public void GetMessages(string queueName, object options, AsyncResultCallback<List<CloudQueueMessage>> callback) {
        }

        public void ListQueues(AsyncResultCallback<List<CloudQueue>> callback) {
        }

        public void ListQueues(object options, AsyncResultCallback<List<CloudQueue>> callback) {
        }

        public void PeekMessages(string queueName, AsyncResultCallback<List<CloudQueueMessage>> callback) {
        }

        public void PeekMessages(string queueName, object options, AsyncResultCallback<List<CloudQueueMessage>> callback) {
        }

        public void UpdateMessage(string queueName, string messageID, string popReceipt, int visibilityTimeout, AsyncResultCallback<CloudQueueMessage> callback) {
        }

        public void UpdateMessage(string queueName, string messageID, string popReceipt, int visibilityTimeout, object options, AsyncResultCallback<CloudQueueMessage> callback) {
        }
    }
}
