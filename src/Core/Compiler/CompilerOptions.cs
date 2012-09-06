// CompilerOptions.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    /// <summary>
    /// Script# compiler options.
    /// </summary>
    public sealed class CompilerOptions {

        private ICollection<string> _references;
        private ICollection<string> _defines;
        private ICollection<IStreamSource> _sources;
        private ICollection<IStreamSource> _resources;
        private IStreamSource _templateFile;
        private IStreamSource _scriptFile;
        private IStreamSource _docCommentFile;
        private string _scriptNameSuffix;
        private bool _debugFlavor;
        private bool _includeTests;
        private bool _minimize;

        private string _testsSubnamespace;

        private List<string> _executionDependencies;
        private List<string> _referencedDependencies;

        private bool _hasTestTypes;

        // TODO: Get rid of internal test mode/type...
        private bool _internalTestMode;
        private string _internalTestType;

        public CompilerOptions() {
            _testsSubnamespace = ".Tests";
        }

        public bool DebugFlavor {
            get {
                return _debugFlavor;
            }
            set {
                _debugFlavor = value;
            }
        }

        public ICollection<string> Defines {
            get {
                return _defines;
            }
            set {
                _defines = value;
            }
        }

        public IStreamSource DocCommentFile {
            get {
                return _docCommentFile;
            }
            set {
                _docCommentFile = value;
            }
        }

        public bool EnableDocComments {
            get {
                if (DebugFlavor) {
                    return (_docCommentFile != null);
                }
                return false;
            }
        }

        public IEnumerable<string> ExecutionDependencies {
            get {
                return _executionDependencies;
            }
        }

        public bool HasTestTypes {
            get {
                return _hasTestTypes;
            }
            set {
                _hasTestTypes = value;
            }
        }

        public bool IncludeTests {
            get {
                return _includeTests;
            }
            set {
                _includeTests = value;
            }
        }

        public bool InternalTestMode {
            get {
                return _internalTestMode;
            }
            set {
                _internalTestMode = value;
            }
        }

        public string InternalTestType {
            get {
                return _internalTestType;
            }
            set {
                _internalTestType = value;
            }
        }

        public bool Minimize {
            get {
                if (!DebugFlavor) {
                    return _minimize;
                }
                return false;
            }
            set {
                _minimize = value;
            }
        }

        public ICollection<string> References {
            get {
                return _references;
            }
            set {
                _references = value;
                _referencedDependencies = null;
            }
        }

        public ICollection<IStreamSource> Resources {
            get {
                return _resources;
            }
            set {
                _resources = value;
            }
        }

        public IStreamSource ScriptFile {
            get {
                return _scriptFile;
            }
            set {
                _scriptFile = value;
            }
        }

        public string ScriptNameSuffix {
            get {
                return _scriptNameSuffix ?? String.Empty;
            }
            set {
                _scriptNameSuffix = value;
            }
        }

        public ICollection<IStreamSource> Sources {
            get {
                return _sources;
            }
            set {
                _sources = value;
            }
        }

        public IStreamSource TemplateFile {
            get {
                return _templateFile;
            }
            set {
                _templateFile = value;
            }
        }

        public string TestsSubnamespace {
            get {
                return _testsSubnamespace;
            }
            set {
                _testsSubnamespace = value;
            }
        }

        public void AddExecutionDependency(string scriptName) {
            if (_executionDependencies == null) {
                _executionDependencies = new List<string>();
            }
            if (_executionDependencies.Contains(scriptName) == false) {
                _executionDependencies.Add(scriptName);
            }
        }

        public void AddReferencedDependency(string scriptName) {
            if (_referencedDependencies == null) {
                _referencedDependencies = new List<string>();
            }
            _referencedDependencies.Add(scriptName);
        }

        public bool Validate(out string errorMessage) {
            errorMessage = String.Empty;

            if (References.Count == 0) {
                errorMessage = "You must specify a list of valid assembly references.";
                return false;
            }

            if (Sources.Count == 0) {
                errorMessage = "You must specify a list of valid source files.";
                return false;
            }

            if (ScriptFile == null) {
                errorMessage = "You must specify a valid output script file.";
                return false;
            }

            return true;
        }
    }
}
