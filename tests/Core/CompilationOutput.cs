// CompilationOutput.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using System.Text;

namespace DSharp.Tests.Core {

    public sealed class CompilationOutput : IStreamSource {

        private string _name;
        private string _generatedOutput;

        public CompilationOutput(string name) {
            _name = name;
        }

        public string GeneratedOutput {
            get {
                return _generatedOutput;
            }
        }

        #region Implementation of IStreamSource

        string IStreamSource.FullName {
            get {
                return _name;
            }
        }

        string IStreamSource.Name {
            get {
                return _name;
            }
        }

        void IStreamSource.CloseStream(Stream stream) {
            MemoryStream ms = (MemoryStream)stream;
            byte[] buffer = ms.GetBuffer();

            _generatedOutput = Encoding.UTF8.GetString(buffer, 0, (int)ms.Length);
            ms.Close();
        }

        Stream IStreamSource.GetStream() {
            return new MemoryStream();
        }

        #endregion
    }
}
