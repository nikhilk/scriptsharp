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

        public static void AppendFile(string fileName, string data, Action<Exception> callback) {
        }

        public static void AppendFile(string fileName, string data, Encoding encoding, Action<Exception> callback) {
        }

        public static void AppendFile(string fileName, Buffer data) {
        }

        public static void AppendFile(string fileName, Buffer data, Action<Exception> callback) {
        }

        public static void AppendFileSync(string fileName, string data) {
        }

        public static void AppendFileSync(string fileName, string data, Encoding encoding) {
        }

        public static void AppendFileSync(string fileName, Buffer data) {
        }

        public static void Close(FileDescriptor fd) {
        }

        public static void Close(FileDescriptor fd, Action<Exception> callback) {
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
        public static void MakeDirectory(string path, Action<Exception> callback) {
        }

        [ScriptName("mkdirSync")]
        public static void MakeDirectorySync(string path) {
        }

        public static void Open(string path, FileAccess flags, Action<FileDescriptor> callback) {
        }

        public static void Open(string path, FileAccess flags, int mode, Action<FileDescriptor> callback) {
        }

        public static FileDescriptor OpenSync(string path, string flags) {
            return null;
        }

        public static FileDescriptor OpenSync(string path, string flags, string mode) {
            return null;
        }

        public static void Read(FileDescriptor fd, Buffer buffer, int offset, int length, object position, Action<Exception, int, Buffer> callback) {
        }

        public static int ReadSync(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
            return 0;
        }

        [ScriptName("readdir")]
        public static void ReadDirectory(string path, Action<Exception, string[]> callback) {
        }

        [ScriptName("readdirSync")]
        public static string[] ReadDirectorySync(string path) {
            return null;
        }

        public static void ReadFile(string fileName, Action<Exception, Buffer> callback) {
        }

        [ScriptName("readFile")]
        public static void ReadFileText(string fileName, Action<Exception, string> callback) {
        }

        [ScriptName("readFile")]
        public static void ReadFileText(string fileName, Encoding encoding, Action<Exception, string> callback) {
        }

        public static Buffer ReadFileSync(string fileName) {
            return null;
        }

        [ScriptName("readFile")]
        public static string ReadFileTextSync(string fileName) {
            return null;
        }

        [ScriptName("readFile")]
        public static string ReadFileTextSync(string fileName, Encoding encoding) {
            return null;
        }

        [ScriptName("rmdir")]
        public static void RemoveDirectory(string path) {
        }

        [ScriptName("rmdir")]
        public static void RemoveDirectory(string path, Action<Exception> callback) {
        }

        [ScriptName("rmdirSync")]
        public static void RemoveDirectorySync(string path) {
        }

        public static void Rename(string oldPath, string newPath) {
        }

        public static void Rename(string oldPath, string newPath, Action<Exception> callback) {
        }

        public static void RenameSync(string oldPath, string newPath) {
        }

        public static void Stat(string path, Action<Exception, FileStats> callback) {
        }

        public static FileStats StatSync(string path) {
            return null;
        }

        public static void Truncate(FileDescriptor fd, int length) {
        }

        public static void Truncate(FileDescriptor fd, int length, Action<Exception> callback) {
        }

        public static void TruncateSync(FileDescriptor fd, int length) {
        }

        public static FileSystemWatcher UnwatchFile(string fileName) {
            return null;
        }

        public static FileSystemWatcher UnwatchFile(string fileName, Action<FileSystemChange, string> listener) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName, Action<FileSystemChange, string> listener) {
            return null;
        }

        public static FileSystemWatcher Watch(string fileName, FileSystemWatchOptions options, Action<FileSystemChange, string> listener) {
            return null;
        }

        public static void Write(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
        }

        public static void Write(FileDescriptor fd, Buffer buffer, int offset, int length, object position, Action<Exception, int, Buffer> callback) {
        }

        public static int WriteSync(FileDescriptor fd, Buffer buffer, int offset, int length, object position) {
            return 0;
        }

        public static void WriteFile(string fileName, string data) {
        }

        public static void WriteFile(string fileName, string data, Encoding encoding) {
        }

        public static void WriteFile(string fileName, string data, Action<Exception> callback) {
        }

        public static void WriteFile(string fileName, string data, Encoding encoding, Action<Exception> callback) {
        }

        public static void WriteFile(string fileName, Buffer data) {
        }

        public static void WriteFile(string fileName, Buffer data, Action<Exception> callback) {
        }

        public static void WriteFileSync(string fileName, string data) {
        }

        public static void WriteFileSync(string fileName, string data, Encoding encoding) {
        }

        public static void WriteFileSync(string fileName, Buffer data) {
        }
    }
}
