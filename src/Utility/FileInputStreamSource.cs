// FileInputStreamSource.cs
// Script#/Common
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    internal class FileInputStreamSource : IStreamSource {

        private string _path;
        private string _name;

        public FileInputStreamSource(string path)
            : this(path, path) {
        }

        public FileInputStreamSource(string path, string name) {
            _path = path;
            _name = name;
        }

        public string FullName {
            get {
                return Path.GetFullPath(_path);
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        public void CloseStream(Stream stream) {
            Debug.Assert(stream != null);
            Debug.Assert(stream is FileStream);

            stream.Close();
        }

        public Stream GetStream() {
            try {
                return new FileStream(FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch {
                return null;
            }
        }
    }
}
