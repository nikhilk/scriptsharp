// SimpleCompilation.cs
// Script#/Tests
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSharp;

namespace DSharp.Tests.Core {

    public sealed class SimpleCompilation : IErrorHandler {

        private List<string> _references;
        private List<IStreamSource> _sources;
        private IStreamSource _output;

        private CompilerOptions _options;

        private List<string> _errors;

        public SimpleCompilation(string outputPath) {
            _references = new List<string>();
            _sources = new List<IStreamSource>();
            _output = new FileStreamSource(outputPath, writable: true);

            _options = new CompilerOptions();
            _options.Minimize = false;
        }

        public bool HasErrors {
            get {
                return _errors.Count != 0;
            }
        }

        public SimpleCompilation AddReference(string path) {
            _references.Add(path);
            return this;
        }

        public SimpleCompilation AddSource(string path) {
            FileStreamSource sourceInput = new FileStreamSource(path, writable: false);
            _sources.Add(sourceInput);

            return this;
        }

        public bool Execute() {
            _options.References = _references;
            _options.Sources = _sources.Cast<IStreamSource>().ToList();
            _options.ScriptFile = _output;

            ScriptCompiler compiler = new ScriptCompiler(this);
            return compiler.Compile(_options);
        }

        #region Implementation of IErrorHandler

        void IErrorHandler.ReportError(string errorMessage, string location) {
            if (_errors == null) {
                _errors = new List<string>();
            }

            string error = errorMessage + " " + location;
            _errors.Add(error);
        }

        #endregion


        private sealed class FileStreamSource : IStreamSource {

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
}
