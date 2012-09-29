// PreprocessorOptions.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp {

    /// <summary>
    /// Script# pre-processor options.
    /// </summary>
    internal sealed class PreprocessorOptions {

        private ICollection<string> _preprocessorVariables;
        private IStreamSource _sourceFile;
        private IStreamSource _targetFile;
        private bool _stripCommentsOnly;
        private bool _useWindowsLineBreaks;
        private bool _debug;
        private bool _minimize;

        public bool DebugFlavor {
            get {
                return _debug;
            }
            set {
                _debug = value;
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

        public ICollection<string> PreprocessorVariables {
            get {
                return _preprocessorVariables;
            }
            set {
                _preprocessorVariables = value;
            }
        }

        public IStreamSource SourceFile {
            get {
                return _sourceFile;
            }
            set {
                _sourceFile = value;
            }
        }

        public bool StripCommentsOnly {
            get {
                return _stripCommentsOnly;
            }
            set {
                _stripCommentsOnly = value;
            }
        }

        public IStreamSource TargetFile {
            get {
                return _targetFile;
            }
            set {
                _targetFile = value;
            }
        }

        public bool UseWindowsLineBreaks {
            get {
                return _useWindowsLineBreaks;
            }
            set {
                _useWindowsLineBreaks = value;
            }
        }
    }
}
