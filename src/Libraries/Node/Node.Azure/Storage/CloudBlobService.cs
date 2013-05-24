// CloudBlobService.cs
// Script#/Libraries/Node/Azure
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeApi.IO;

namespace NodeApi.WindowsAzure.Storage {

    // TODO: ACLs
    // TODO: Page blobs
    // TODO: Shared access signatures
    // TODO: Metadata/properties

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class CloudBlobService {

        private CloudBlobService() {
        }

        public void AcquireLease(string containerName, string blobName, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void AcquireLease(string containerName, string blobName, object options, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void BreakLease(string containerName, string blobName, string leaseID, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void BreakLease(string containerName, string blobName, string leaseID, object options, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void CopyBlob(string sourceContainerName, string sourceBlobName, string targetContainerName, string targetBlobName, AsyncResultCallback<CloudBlob> callback) {
        }

        public void CopyBlob(string sourceContainerName, string sourceBlobName, string targetContainerName, string targetBlobName, object options, AsyncResultCallback<CloudBlob> callback) {
        }

        public void CreateBlobSnapshot(string containerName, string blobName, AsyncResultCallback<string> callback) {
        }

        public void CreateBlobSnapshot(string containerName, string blobName, object options, AsyncResultCallback<string> callback) {
        }

        public void CreateBlockBlobFromFile(string containerName, string blobName, string fileName, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateBlockBlobFromFile(string containerName, string blobName, string fileName, object options, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateBlockBlobFromStream(string containerName, string blobName, ReadableStream stream, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateBlockBlobFromStream(string containerName, string blobName, ReadableStream stream, object options, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateBlockBlobFromText(string containerName, string blobName, string text, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateBlockBlobFromText(string containerName, string blobName, string text, object options, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void CreateContainer(string containerName, AsyncCallback callback) {
        }

        public void CreateContainer(string containerName, object options, AsyncCallback callback) {
        }

        public void CreateContainerIfNotExists(string containerName, AsyncCallback callback) {
        }

        public void CreateContainerIfNotExists(string containerName, object options, AsyncCallback callback) {
        }

        public void DeleteBlob(string containerName, string blobName, AsyncCallback callback) {
        }

        public void DeleteBlob(string containerName, string blobName, object options, AsyncCallback callback) {
        }

        public void DeleteContainer(string containerName, AsyncCallback callback) {
        }

        public void DeleteContainer(string containerName, object options, AsyncCallback callback) {
        }

        public void GetBlobToFile(string containerName, string blobName, string fileName, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void GetBlobToFile(string containerName, string blobName, string fileName, object options, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void GetBlobToStream(string containerName, string blobName, WritableStream stream, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void GetBlobToStream(string containerName, string blobName, WritableStream stream, object options, AsyncResultCallback<CloudBlockBlob> callback) {
        }

        public void GetBlobToText(string containerName, string blobName, string text, AsyncResultCallback<string, CloudBlockBlob> callback) {
        }

        public void GetBlobToText(string containerName, string blobName, string text, object options, AsyncResultCallback<string, CloudBlockBlob> callback) {
        }

        public void ListBlobs(string containerName, AsyncResultCallback<List<CloudBlob>> callback) {
        }

        public void ListBlobs(string containerName, AsyncResultCallback<List<CloudBlob>, CloudBlobListContinuation> callback) {
        }

        public void ListBlobs(string containerName, object options, AsyncResultCallback<List<CloudBlob>> callback) {
        }

        public void ListBlobs(string containerName, object options, AsyncResultCallback<List<CloudBlob>, CloudBlobListContinuation> callback) {
        }

        public void ListContainers(AsyncResultCallback<List<CloudBlobContainer>> callback) {
        }

        public void ListContainers(AsyncResultCallback<List<CloudBlobContainer>, CloudBlobContainerListContinuation> callback) {
        }

        public void ListContainers(object options, AsyncResultCallback<List<CloudBlobContainer>> callback) {
        }

        public void ListContainers(object options, AsyncResultCallback<List<CloudBlobContainer>, CloudBlobContainerListContinuation> callback) {
        }

        public void ReleaseLease(string containerName, string blobName, string leaseID, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void ReleaseLease(string containerName, string blobName, string leaseID, object options, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void RenewLease(string containerName, string blobName, string leaseID, AsyncResultCallback<CloudBlobLease> callback) {
        }

        public void RenewLease(string containerName, string blobName, string leaseID, object options, AsyncResultCallback<CloudBlobLease> callback) {
        }
    }
}
