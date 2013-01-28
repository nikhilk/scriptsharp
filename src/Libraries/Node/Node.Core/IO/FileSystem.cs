// FileSystem.cs
// Script#/Libraries/Node/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.IO {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    [ScriptDependency("fs")]
    [ScriptName("fs")]
    public static class FileSystem {

        public static void AppendFile(string fileName, string data) {
        }

        public static void AppendFile(string fileName, string data, Encoding encoding) {
        }

        public static void AppendFile(string fileName, string data, AsyncCallback callback) {
        }

        public static void AppendFile(string fileName, string data, Encoding encoding, AsyncCallback callback) {
        }

        public static void AppendFile(string fileName, Buffer data) {
        }

        public static void AppendFile(string fileName, Buffer data, AsyncCallback callback) {
        }

        public static void AppendFileSync(string fileName, string data) {
        }

        public static void AppendFileSync(string fileName, string data, Encoding encoding) {
        }

        public static void AppendFileSync(string fileName, Buffer data) {
        }

        public static void Close(FileDescriptor fd) {
        }

        public static void Close(FileDescriptor fd, AsyncCallback callback) {
        }

        public static void CloseSync(FileDescriptor fd) {
        }

        public static ReadStream CreateReadStream(string path) {
            return null;
        }

        public static ReadStream CreateReadStream(string path, ReadStreamOptions options) {
            return null;
        }

        public static WriteStream CreateWriteStream(string path) {
            return null;
        }

        public static WriteStream CreateWriteStream(string path, WriteStreamOptions options) {
            return null;
        }

        public static void Exists(string path, Action<bool> callback) {
        }

        public static bool ExistsSync(string path) {
            return false;
        }

        [ScriptName("mkdir")]
        public static void MakeDirectory(string path) {
        }

        [ScriptName("mkdir")]
        public static void MakeDirectory(string path, AsyncCallback callback) {
        }

        [ScriptName("mkdirSync")]
        public static void MakeDirectorySync(string path) {
        }

        public static void Open(string path, FileAccess flags, AsyncResultCallback<FileDescriptor> callback) {
        }

        public static void Open(string path, FileAccess flags, int mode, AsyncResultCallback<FileDescriptor> callback) {
        }

        public static FileDescriptor OpenSync(string path, string flags) {
            return null;
        }

        public static FileDescriptor OpenSync(string path, string flags, string mode) {
            return null;
        }

        public static void Read(FileDescriptor fd, Buffer buffer, int offset, int length, object position, AsyncResultCallback<int, Buffer> callback) {
        }

        public static int ReadSync(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
            return 0;
        }

        [ScriptName("readdir")]
        public static void ReadDirectory(string path, AsyncResultCallback<string[]> callback) {
        }

        [ScriptName("readdirSync")]
        public static string[] ReadDirectorySync(string path) {
            return null;
        }

        public static void ReadFile(string fileName, AsyncResultCallback<Buffer> callback) {
        }

        [ScriptName("readFile")]
        public static void ReadFileText(string fileName, Encoding encoding, AsyncResultCallback<string> callback) {
        }

        public static Buffer ReadFileSync(string fileName) {
            return null;
        }

        [ScriptName("readFileSync")]
        public static string ReadFileTextSync(string fileName, Encoding encoding) {
            return null;
        }

        [ScriptName("rmdir")]
        public static void RemoveDirectory(string path) {
        }

        [ScriptName("rmdir")]
        public static void RemoveDirectory(string path, AsyncCallback callback) {
        }

        [ScriptName("rmdirSync")]
        public static void RemoveDirectorySync(string path) {
        }

        public static void Rename(string oldPath, string newPath) {
        }

        public static void Rename(string oldPath, string newPath, AsyncCallback callback) {
        }

        public static void RenameSync(string oldPath, string newPath) {
        }

        public static void Stat(string path, AsyncResultCallback<FileStats> callback) {
        }

        public static FileStats StatSync(string path) {
            return null;
        }

        public static void Truncate(FileDescriptor fd, int length) {
        }

        public static void Truncate(FileDescriptor fd, int length, AsyncCallback callback) {
        }

        public static void TruncateSync(FileDescriptor fd, int length) {
        }

        public static FileSystemWatcher UnwatchFile(string fileName) {
            return null;
        }

        public static FileSystemWatcher UnwatchFile(string fileName, FileSystemListener listener) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName, FileSystemListener listener) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName, FileSystemWatchOptions options, FileSystemListener listener) {
            return null;
        }

        public static void Write(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
        }

        public static void Write(FileDescriptor fd, Buffer buffer, int offset, int length, object position, AsyncResultCallback<int, Buffer> callback) {
        }

        public static int WriteSync(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
            return 0;
        }

        public static void WriteFile(string fileName, string data) {
        }

        public static void WriteFile(string fileName, string data, Encoding encoding) {
        }

        public static void WriteFile(string fileName, string data, AsyncCallback callback) {
        }

        public static void WriteFile(string fileName, string data, Encoding encoding, AsyncCallback callback) {
        }

        public static void WriteFile(string fileName, Buffer data) {
        }

        public static void WriteFile(string fileName, Buffer data, AsyncCallback callback) {
        }

        public static void WriteFileSync(string fileName, string data) {
        }

        public static void WriteFileSync(string fileName, string data, Encoding encoding) {
        }

        public static void WriteFileSync(string fileName, Buffer data) {
        }
    }
}
