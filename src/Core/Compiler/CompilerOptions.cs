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
        private IStreamSource _scriptFile;
        private IStreamSource _docCommentFile;
        private bool _includeTests;
        private bool _minimize;
        private ScriptInfo _scriptInfo;

        private string _testsSubnamespace;

        private bool _hasTestTypes;

        // TODO: Get rid of internal test mode/type...
        private bool _internalTestMode;
        private string _internalTestType;

        public CompilerOptions() {
            _scriptInfo = new ScriptInfo();
            _testsSubnamespace = ".Tests";
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
                return (_docCommentFile != null);
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
                return _minimize;
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

        public ScriptInfo ScriptInfo {
            get {
                return _scriptInfo;
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

        public ICollection<IStreamSource> Sources {
            get {
                return _sources;
            }
            set {
                _sources = value;
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
