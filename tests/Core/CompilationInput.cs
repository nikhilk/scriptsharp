// CompilationInput.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using System.Text;

namespace DSharp.Tests.Core {

    public sealed class CompilationInput : IStreamSource {

        private string _path;
        private string _name;
        private string _content;

        public CompilationInput(string path, string name) {
            _path = path;
            _name = name;
        }

        public CompilationInput(string path, string name, string content) {
            _path = path;
            _name = name;
            _content = content;
        }

        #region Implementation of IStreamSource

        string IStreamSource.FullName {
            get {
                return _path;
            }
        }

        string IStreamSource.Name {
            get {
                return _name;
            }
        }

        void IStreamSource.CloseStream(Stream stream) {
            stream.Close();
        }

        Stream IStreamSource.GetStream() {
            if (_content != null) {
                byte[] data = Encoding.UTF8.GetBytes(_content);
                return new MemoryStream(data);
            }

            return File.OpenRead(_path);
        }

        #endregion
    }
}
