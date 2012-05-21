// FileOutputStreamSource.cs
// Script#/Common
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    internal class FileOutputStreamSource : IStreamSource {

        private string _path;
        private string _name;

        public FileOutputStreamSource(string path)
            : this(path, path) {
        }

        public FileOutputStreamSource(string path, string name) {
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
                string file = FullName;

                string directory = Path.GetDirectoryName(file);
                if (Directory.Exists(directory) == false) {
                    Directory.CreateDirectory(directory);
                }

                return new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
            }
            catch {
                return null;
            }
        }
    }
}
