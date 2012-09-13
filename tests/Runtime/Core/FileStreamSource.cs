// FileStreamSource.cs
// Script#/Tests/Runtime
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using ScriptSharp;

namespace Runtime.Tests.Core {

    public sealed class FileStreamSource : IStreamSource {

        private string _path;
        private bool _writable;

        public FileStreamSource(string path, bool writable) {
            _path = path;
            _writable = writable;
        }

        #region Implementation of IStreamSource

        string IStreamSource.FullName {
            get {
                return _path;
            }
        }

        string IStreamSource.Name {
            get {
                return Path.GetFileNameWithoutExtension(_path);
            }
        }

        void IStreamSource.CloseStream(Stream stream) {
            stream.Close();
        }

        Stream IStreamSource.GetStream() {
            if (_writable) {
                return new FileStream(_path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            }
            else {
                return new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
        }

        #endregion
    }
}
