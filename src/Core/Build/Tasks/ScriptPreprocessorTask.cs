// ScriptPreprocessorTask.cs
// Script#/Tools/Build
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Build;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ScriptSharp.Tasks {

    public sealed class ScriptPreprocessorTask : Task, IErrorHandler, IStreamResolver {

        private bool _debug;
        private bool _minimize;
        private bool _stripCommentsOnly;
        private bool _windowsLineBreaks;
        private string _defines;
        private string _outputDirectory;

        private string[] _preprocessorVariables;

        private ITaskItem[] _sources;
        private ITaskItem[] _scripts;

        private bool _hasErrors;

        public ScriptPreprocessorTask() {
            _minimize = true;
        }

        public bool Debug {
            get {
                return _debug;
            }
            set {
                _debug = value;
            }
        }

        public string Defines {
            get {
                return _defines;
            }
            set {
                _defines = value;
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

        [Required]
        public string OutputDirectory {
            get {
                return _outputDirectory;
            }
            set {
                _outputDirectory = value;
            }
        }

        [Output]
        public ITaskItem[] Scripts {
            get {
                return _scripts;
            }
            set {
                _scripts = value;
            }
        }

        public ITaskItem[] Sources {
            get {
                return _sources;
            }
            set {
                _sources = value;
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

        public bool WindowsLineBreaks {
            get {
                return _windowsLineBreaks;
            }
            set {
                _windowsLineBreaks = value;
            }
        }

        private string ConvertScriptFile(BuildType type, string inputPath) {
            string result = null;
            string outputPath = null;
            try {
                outputPath = Path.Combine(OutputDirectory, Path.ChangeExtension(Path.GetFileName(inputPath), ".js"));

                PreprocessorOptions options = new PreprocessorOptions();
                options.SourceFile = new FileInputStreamSource(inputPath);
                options.TargetFile = new FileOutputStreamSource(outputPath);
                options.DebugFlavor = Debug;
                options.Minimize = Minimize;
                options.StripCommentsOnly = StripCommentsOnly;
                options.UseWindowsLineBreaks = WindowsLineBreaks;
                options.PreprocessorVariables = _preprocessorVariables;

                ScriptPreprocessor preprocessor;
                if (type == BuildType.ScriptAssembly) {
                    preprocessor = new ScriptPreprocessor(this, this);
                }
                else {
                    preprocessor = new ScriptPreprocessor();
                }

                preprocessor.Preprocess(options);
                result = outputPath;
            }
            catch (Exception e) {
#if DEBUG
                Log.LogErrorFromException(e, /* showStackTrace */ true);
#else
                Log.LogErrorFromException(e, /* showStackTrace */ false);
#endif // DEBUG
            }

            if ((result == null) && File.Exists(outputPath)) {
                try {
                    File.Delete(outputPath);
                }
                catch {
                }
            }
            return result;
        }

        private string CopyStandardScriptFile(string inputPath) {
            string result = null;
            string outputPath = null;

            try {
                outputPath = Path.Combine(OutputDirectory, Path.GetFileName(inputPath));

                File.Copy(inputPath, outputPath, /* overwrite */ true);
                File.SetAttributes(outputPath, FileAttributes.Normal);
                result = outputPath;
            }
            catch {
                Log.LogError("'" + outputPath + "' could not be opened for writing.");
            }

            return result;
        }

        public override bool Execute() {
            if ((_sources == null) || (_sources.Length == 0)) {
                Log.LogError("No source files were specified");
                return false;
            }

            for (int i = 0; i < _sources.Length; i++) {
                ITaskItem source = _sources[i];
                if (File.Exists(source.ItemSpec) == false) {
                    Log.LogError("'" + source.ItemSpec + "' was not found.");
                    _hasErrors = true;
                }
            }

            if (_hasErrors) {
                return false;
            }

            if (String.IsNullOrEmpty(Defines) == false) {
                _preprocessorVariables = Defines.Split(',', ';', ' ');
            }

            Log.LogMessage(MessageImportance.Low,
                           String.Format("Parameters: Debug={0}, Minimize={1}, StripCommentsOnly={2}, WindowsLineBreaks={3}\r\n            Defines={4}",
                                         Debug, Minimize, StripCommentsOnly, WindowsLineBreaks, Defines));

            ArrayList scripts = new ArrayList(_sources.Length);
            for (int i = 0; i < _sources.Length; i++) {
                ITaskItem source = _sources[i];

                string sourcePath = source.ItemSpec;
                string outputPath = null;
                BuildType type = BuildType.Unknown;

                string extension = Path.GetExtension(sourcePath);
                if (String.Compare(extension, ".jsa", StringComparison.OrdinalIgnoreCase) == 0) {
                    type = BuildType.ScriptAssembly;
                }
                else if (String.Compare(extension, ".jsx", StringComparison.OrdinalIgnoreCase) == 0) {
                    type = BuildType.ExtendedScript;
                }
                else if (String.Compare(extension, ".js", StringComparison.OrdinalIgnoreCase) == 0) {
                    type = BuildType.StandardScript;
                }
                else {
                    Log.LogError("'" + sourcePath + "' is an unknown file type.");
                    _hasErrors = true;
                }

                if (type != BuildType.Unknown) {
                    Log.LogMessage(MessageImportance.Low, "Building '" + sourcePath + "'");
                    if (type == BuildType.StandardScript) {
                        outputPath = CopyStandardScriptFile(sourcePath);
                    }
                    else {
                        outputPath = ConvertScriptFile(type, sourcePath);
                    }

                    if (String.IsNullOrEmpty(outputPath) == false) {
                        scripts.Add(new TaskItem(outputPath));
                    }
                    else {
                        _hasErrors = true;
                    }
                }
            }

            if (_hasErrors == false) {
                _scripts = (ITaskItem[])scripts.ToArray(typeof(ITaskItem));
                return true;
            }
            return false;
        }

        #region Implementation of IErrorHandler
        void IErrorHandler.ReportError(string errorMessage, string location) {
            _hasErrors = true;

            int line = 0;
            int column = 0;

            if (String.IsNullOrEmpty(location) == false) {
                if (location.EndsWith(")", StringComparison.Ordinal)) {
                    int index = location.LastIndexOf("(", StringComparison.Ordinal);
                    System.Diagnostics.Debug.Assert(index > 0);

                    string position = location.Substring(index + 1, location.Length - index - 2);
                    string[] positionParts = position.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    System.Diagnostics.Debug.Assert(positionParts.Length == 2);

                    Int32.TryParse(positionParts[0], out line);
                    Int32.TryParse(positionParts[1], out column);

                    location = location.Substring(0, index);
                }
            }

            Log.LogError(String.Empty, String.Empty, String.Empty, location, line, column, 0, 0, errorMessage);
        }
        #endregion

        #region Implementation of IStreamResolver
        IStreamSource IStreamResolver.ResolveInclude(IStreamSource baseStream, string includePath) {
            string resolvedPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(baseStream.FullName)), includePath);
            return new FileInputStreamSource(resolvedPath);
        }
        #endregion

        private enum BuildType {

            Unknown = 0,

            StandardScript = 1,

            ExtendedScript = 2,

            ScriptAssembly = 3
        }
    }
}
