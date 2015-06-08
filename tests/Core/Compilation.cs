// Compilation.cs
// Script#/Tests/ScriptSharp
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScriptSharp.Tests.Core {

    public sealed class Compilation : IErrorHandler, IStreamSourceResolver {

        private CompilationTest _test;

        private List<string> _references;
        private List<CompilationInput> _sources;
        private List<CompilationInput> _resources;
        private CompilationInput _comments;
        private CompilationOutput _output;
        private IStreamSourceResolver _includeResolver;

        private List<string> _errors;

        private CompilerOptions _options;

        public Compilation(CompilationTest test) {
            _test = test;

            _references = new List<string>();
            _sources = new List<CompilationInput>();
            _resources = new List<CompilationInput>();

            _options = new CompilerOptions();
            _options.Minimize = false;
            _options.InternalTestMode = true;
            _options.Defines = new string[] { };
        }

        public string ErrorMessages {
            get {
                return String.Join(Environment.NewLine, Errors);
            }
        }

        public IEnumerable<string> Errors {
            get {
                return _errors;
            }
        }

        public bool HasErrors {
            get {
                return _errors != null;
            }
        }

        public CompilerOptions Options {
            get {
                return _options;
            }
        }

        public CompilationOutput Output {
            get {
                return _output;
            }
        }

        public Compilation AddCode(string name, string code) {
            string sourcePath = _test.GetTestFilePath(name);

            CompilationInput codeInput = new CompilationInput(sourcePath, name, code);
            _sources.Add(codeInput);

            return this;
        }

        public Compilation AddComments(string name) {
            string commentsPath = _test.GetTestFilePath(name);

            _comments = new CompilationInput(commentsPath, name);
            return this;
        }

        public void AddIncludeResolver() {
            _includeResolver = this;
        }

        public Compilation AddReference(string name) {
            string assemblyPath = _test.GetAssemblyFilePath(name);
            if (File.Exists(assemblyPath)) {
                _references.Add(assemblyPath);
            }
            else {
                assemblyPath = _test.GetTestFilePath(name);
                if (File.Exists(assemblyPath)) {
                    _references.Add(assemblyPath);
                }
            }

            return this;
        }

        public Compilation AddResource(string name) {
            string resourcesPath = _test.GetTestFilePath(name);

            CompilationInput resourceInput = new CompilationInput(resourcesPath, name);
            _resources.Add(resourceInput);

            return this;
        }

        public Compilation AddSource(string name) {
            string sourcePath = _test.GetTestFilePath(name);

            CompilationInput sourceInput = new CompilationInput(sourcePath, name);
            _sources.Add(sourceInput);

            return this;
        }

        public bool Execute() {
            _output = new CompilationOutput(_test.TestContext.TestName);

            _options.References = _references;
            _options.Sources = _sources.Cast<IStreamSource>().ToList();
            _options.Resources = _resources.Cast<IStreamSource>().ToList();
            _options.DocCommentFile = _comments;
            _options.ScriptFile = _output;
            _options.IncludeResolver = _includeResolver;

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
            _test.TestContext.WriteLine(error);
        }

        #endregion

        #region Implementation of IStreamSourceResolver

        IStreamSource IStreamSourceResolver.Resolve(string name) {
            string path = _test.GetTestFilePath(name);
            return new CompilationInput(path, name);
        }

        #endregion
    }
}
